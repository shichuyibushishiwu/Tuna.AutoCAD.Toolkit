using Autodesk.AutoCAD.DatabaseServices.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tuna.AutoCAD.Toolkit.Filter.ClassFilter;

namespace Tuna.AutoCAD.Toolkit.Filter;

public class ParameterFilter : FilterBase
{
    public ParameterFilter(Type type, params FilterRule[] rules)
    {
        if (type == null)
        {
            throw new ArgumentNullException("type can not be null");
        }

        AcadTypeDescriptor? descriptor = TypeDescriptors.FirstOrDefault(descriptor => descriptor.Type == type);
        if (descriptor == null)
        {
            throw new ArgumentNullException($"can not find {type} in allowed type list");
        }

        LogicalAndFilter = new LogicalAndFilter(
            new ClassFilter(type),
            new CustomFilter(rules.Select(rule => rule.TypedValue).ToArray()));

        TypeValues = LogicalAndFilter.TypeValues;
    }

    protected LogicalAndFilter LogicalAndFilter { get; set; }

    public override string ToString()
    {
        return LogicalAndFilter.ToString();
    }
}

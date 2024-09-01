using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// A base class of logical filter
/// </summary>
public abstract class LogicalFilter : FilterBase
{
    protected FilterBase[] Filters { get; set; } = default!;

    protected LogicalFilter(string logicalCode, FilterBase[] filters)
    {
        if (filters == null)
        {
            throw new ArgumentNullException("");
        }

        LogicalCode = logicalCode;
        Filters = filters;

        List<TypedValue> typedValues = new List<TypedValue>();

        typedValues.Add(new TypedValue(ACADFilterTypeCode.Operator, $"<{logicalCode}"));
        typedValues.AddRange(filters.SelectMany(f => f.TypeValues));
        typedValues.Add(new TypedValue(ACADFilterTypeCode.Operator, $"{logicalCode}>"));

        TypeValues = typedValues.ToArray();
    }

    protected string LogicalCode { get; set; }

    public override string ToString()
    {
        Type type = this.GetType();
        FilterDxfCodeAttribute? attribute = type.GetCustomAttribute<FilterDxfCodeAttribute>();
        if (attribute == null)
        {
            return $"{type}";
        }

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"<{LogicalCode}");
        foreach (var filter in Filters)
        {
            stringBuilder.AppendLine($"{filter}");
        }
        stringBuilder.Append($"{LogicalCode}>");
        return stringBuilder.ToString();
    }
}

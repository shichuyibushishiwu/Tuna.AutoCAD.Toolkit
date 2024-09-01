using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// A filter that contains a set of filters
/// </summary>
[FilterDxfCode(Autodesk.AutoCAD.DatabaseServices.DxfCode.Operator)]
public sealed class LogicalOrFilter : LogicalFilter
{
    public LogicalOrFilter(params FilterBase[] filters) : base("Or", filters)
    {
        var typeGrounp = filters.GroupBy(filter => filter.GetType());
        if (typeGrounp.Count() != 1)
        {
            throw new Exception("Logical or can not contains the different conditions");
        }
    }
}

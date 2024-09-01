using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// A filter 
/// </summary>
[FilterDxfCode(Autodesk.AutoCAD.DatabaseServices.DxfCode.Operator)]
public sealed class LogicalAndFilter : LogicalFilter
{
    /// <summary>
    /// Create a logical and filter
    /// </summary>
    /// <param name="filters"></param>
    /// <exception cref="Exception"></exception>
    public LogicalAndFilter(params FilterBase[] filters) : base("And", filters)
    {
        var typeGrounp = filters.GroupBy(filter => filter.GetType());
        if (typeGrounp.Any(g => g.Count() > 1))
        {
            throw new Exception("Logical and can not contains the same conditions");
        }
    }
}

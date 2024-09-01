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
    public LogicalAndFilter(params FilterBase[] filters) : base("And", filters)
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

[FilterDxfCode(Autodesk.AutoCAD.DatabaseServices.DxfCode.Operator)]
public class LogicalNotFilter : LogicalFilter
{
    public LogicalNotFilter(params FilterBase[] filters) : base("NOT", filters)
    {

    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter
{
    /// <summary>
    /// =
    /// </summary>
    internal class FilterEqualsRule : FilterRule
    {
        public FilterEqualsRule()
        {
            new TypedValue(AcadFilterTypeCode.Operator, "=");
        }
    }
}

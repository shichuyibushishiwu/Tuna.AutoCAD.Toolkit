using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// 
/// </summary>
public class FilterStringContainsRule : FilterRule
{
    public FilterStringContainsRule(short parameterCode, string value)
    {
        this.TypedValue = new TypedValue(parameterCode, $"*{value}*");
    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// Create a custom filter
/// </summary>
public class CustomFilter : FilterBase
{
    public CustomFilter(params TypedValue[] typedValues)
    {
        TypeValues = typedValues == null || typedValues.Length == 0 ? [] : typedValues;
    }
}

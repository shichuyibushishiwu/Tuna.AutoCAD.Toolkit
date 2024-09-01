using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

public class CustomFilter : FilterBase
{
    public CustomFilter(params TypedValue[] typedValues)
    {
        TypeValues = typedValues;
    }
}

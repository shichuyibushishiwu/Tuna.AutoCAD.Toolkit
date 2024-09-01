using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

[FilterDxfCode(Autodesk.AutoCAD.DatabaseServices.DxfCode.Color)]
public class ColorFilter : FilterBase
{
    public ColorFilter(short colorIndex)
    {
        ColorIndex = colorIndex;
        TypeValues = [new TypedValue(AcadFilterTypeCode.Color, colorIndex)];
    }

    public short ColorIndex { get; set; }

    public override string ToString()
    {
        return $"{GetCodeAttribute()?.DxfCode} = {ColorIndex}";
    }
}

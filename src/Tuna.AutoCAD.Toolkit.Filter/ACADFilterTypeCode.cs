using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

public class ACADFilterTypeCode
{
    /// <summary>
    /// <see cref="Autodesk.AutoCAD.DatabaseServices.DxfCode.Operator"/>
    /// </summary>
    public const short Operator = -4;

    /// <summary>
    /// <see cref="Autodesk.AutoCAD.DatabaseServices.DxfCode.Start"/>
    /// </summary>
    public const short Class = 1;

    /// <summary>
    /// <see cref="Autodesk.AutoCAD.DatabaseServices.DxfCode.LayerName"/>
    /// </summary>
    public const short LayerName = 8;
}

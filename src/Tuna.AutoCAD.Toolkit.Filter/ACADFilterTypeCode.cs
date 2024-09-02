using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// Acad filter type code
/// </summary>
public class AcadFilterTypeCode
{
    /// <summary>
    /// <see cref="Autodesk.AutoCAD.DatabaseServices.DxfCode.Operator"/>
    /// </summary>
    public const short Operator = -4;

    /// <summary>
    /// <see cref="Autodesk.AutoCAD.DatabaseServices.DxfCode.Start"/>
    /// </summary>
    public const short Class = 0;

    /// <summary>
    /// <see cref="Autodesk.AutoCAD.DatabaseServices.DxfCode.LayerName"/>
    /// </summary>
    public const short LayerName = 8;

    /// <summary>
    /// <see cref="Autodesk.AutoCAD.DatabaseServices.DxfCode.Color"/>
    /// </summary>
    public const short Color = 62;
}

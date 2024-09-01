using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// Filter attribute
/// </summary>
internal class FilterDxfCodeAttribute : Attribute
{
    public FilterDxfCodeAttribute(DxfCode code)
    {
        DxfCode = code;
    }

    /// <summary>
    /// Acad dxf code
    /// </summary>
    public DxfCode DxfCode { get; }
}

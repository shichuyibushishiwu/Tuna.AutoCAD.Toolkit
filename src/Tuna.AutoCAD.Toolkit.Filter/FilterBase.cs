using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Reflection;
using System.Text;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// Defined a base filter type 
/// </summary>
public abstract class FilterBase
{
    /// <summary>
    /// Acad type values
    /// </summary>
    public TypedValue[] TypeValues { get; protected set; } = default!;

    /// <summary>
    /// Get the acad selection filters
    /// </summary>
    /// <returns></returns>
    public SelectionFilter GetSelectionFilter() => new SelectionFilter(TypeValues);

    /// <summary>
    /// Get Acad dxf code attribute
    /// </summary>
    /// <returns></returns>
    internal FilterDxfCodeAttribute? GetCodeAttribute()
    {
        return this.GetType().GetCustomAttribute<FilterDxfCodeAttribute>();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public override string? ToString()
    {
        return base.ToString();
    }
}

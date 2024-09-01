using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Reflection;
using System.Text;

namespace Tuna.AutoCAD.Toolkit.Filter;

public abstract class FilterBase
{
    public TypedValue[] TypeValues { get; protected set; } = default!;

    public SelectionFilter GetSelectionFilter() => new SelectionFilter(TypeValues);

    internal FilterDxfCodeAttribute? GetCodeAttribute()
    {
        return this.GetType().GetCustomAttribute<FilterDxfCodeAttribute>();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}

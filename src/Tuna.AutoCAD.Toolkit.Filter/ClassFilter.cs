using Autodesk.AutoCAD.DatabaseServices;
using System;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// A acad entity filter that filters by entity class type
/// </summary>
[FilterDxfCode(code: DxfCode.Start)]
public sealed class ClassFilter : FilterBase
{
    private static ACADTypeDescriptor[] TypeDescriptors { get; } =
    [
        new ACADTypeDescriptor(typeof(Arc),"ARC"),
        new ACADTypeDescriptor(typeof(AttributeDefinition),"ATTDEF"),
        new ACADTypeDescriptor(typeof(AttributeReference),"ATTRIB"),
        new ACADTypeDescriptor(typeof(Body),"BODY"),
        new ACADTypeDescriptor(typeof(Circle),"CIRCLE"),
        new ACADTypeDescriptor(typeof(Dimension),"DIMENSION"),
        new ACADTypeDescriptor(typeof(DBText),"TEXT"),
        new ACADTypeDescriptor(typeof(Ellipse),"ELLIPSE"),
        new ACADTypeDescriptor(typeof(Hatch),"HATCH"),
        new ACADTypeDescriptor(typeof(Helix),"HELIX"),
        new ACADTypeDescriptor(typeof(Image),"IMAGE"),
        new ACADTypeDescriptor(typeof(BlockReference),"INSERT"),
        new ACADTypeDescriptor(typeof(Leader),"LEADER"),
        new ACADTypeDescriptor(typeof(Light),"LIGHT"),
        new ACADTypeDescriptor(typeof(Line),"LINE"),
        new ACADTypeDescriptor(typeof(Polyline),"LWPOLYLINE"),
        new ACADTypeDescriptor(typeof(MLeader),"MLEADER"),
        new ACADTypeDescriptor(typeof(Mline),"MLINE"),
        new ACADTypeDescriptor(typeof(MText),"MTEXT"),
        new ACADTypeDescriptor(typeof(Ole2Frame),"ONE2FRAME"),
    ];

    public ClassFilter(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }

        ACADTypeDescriptor? descriptor = TypeDescriptors.FirstOrDefault(descriptor => descriptor.Type == type);
        if (descriptor == null)
        {
            throw new ArgumentNullException("");
        }

        Code = descriptor.Value.Code;
        TypeValues = [new TypedValue(ACADFilterTypeCode.Class, Code)];
    }

    public string Code { get; }

    /// <summary>
    /// Map of acad type and type code
    /// </summary>
    private struct ACADTypeDescriptor
    {
        /// <summary>
        /// Defined a acad type map
        /// </summary>
        /// <param name="type">Acad entity type</param>
        /// <param name="code">Acad entity code</param>
        public ACADTypeDescriptor(Type type, string code)
        {
            Type = type;
            Code = code;
        }

        /// <summary>
        /// An acad entity type
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Entity code
        /// </summary>
        public string Code { get; set; }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{GetCodeAttribute()?.DxfCode} = {Code}";
    }
}

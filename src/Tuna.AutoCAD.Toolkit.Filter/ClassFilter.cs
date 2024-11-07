using Autodesk.AutoCAD.DatabaseServices;
using System;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// A acad entity filter that filters by entity class type
/// </summary>
[FilterDxfCode(code: DxfCode.Start)]
public sealed class ClassFilter : FilterBase
{
    internal static AcadTypeDescriptor[] TypeDescriptors { get; } =
    [
        new AcadTypeDescriptor(typeof(Arc),"ARC"),
        new AcadTypeDescriptor(typeof(AttributeDefinition),"ATTDEF"),
        new AcadTypeDescriptor(typeof(AttributeReference),"ATTRIB"),
        new AcadTypeDescriptor(typeof(Body),"BODY"),
        new AcadTypeDescriptor(typeof(Circle),"CIRCLE"),
        new AcadTypeDescriptor(typeof(Dimension),"DIMENSION"),
        new AcadTypeDescriptor(typeof(DBText),"TEXT"),
        new AcadTypeDescriptor(typeof(Ellipse),"ELLIPSE"),
        new AcadTypeDescriptor(typeof(Hatch),"HATCH"),
        new AcadTypeDescriptor(typeof(Helix),"HELIX"),
        new AcadTypeDescriptor(typeof(Image),"IMAGE"),
        new AcadTypeDescriptor(typeof(BlockReference),"INSERT"),
        new AcadTypeDescriptor(typeof(Leader),"LEADER"),
        new AcadTypeDescriptor(typeof(Light),"LIGHT"),
        new AcadTypeDescriptor(typeof(Line),"LINE"),
        new AcadTypeDescriptor(typeof(Polyline),"LWPOLYLINE"),
        new AcadTypeDescriptor(typeof(MLeader),"MLEADER"),
        new AcadTypeDescriptor(typeof(Mline),"MLINE"),
        new AcadTypeDescriptor(typeof(MText),"MTEXT"),
        new AcadTypeDescriptor(typeof(Ole2Frame),"ONE2FRAME"),
    ];

    public ClassFilter(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException("type can not be null");
        }

        AcadTypeDescriptor descriptor = TypeDescriptors.FirstOrDefault(descriptor => descriptor.Type == type);
        if (descriptor.Invaild())
        {
            throw new ArgumentException($"can not find {type} in allowed type list");
        }

        Code = descriptor.Code;
        TypeValues = [new TypedValue(AcadFilterTypeCode.Class, Code)];
    }

    public string Code { get; }

    /// <summary>
    /// Map of acad type and type code
    /// </summary>
    internal struct AcadTypeDescriptor
    {
        /// <summary>
        /// Defined a acad type map
        /// </summary>
        /// <param name="type">Acad entity type</param>
        /// <param name="code">Acad entity code</param>
        public AcadTypeDescriptor(Type type, string code)
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

        /// <summary>
        /// Detemined value is null
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public bool Invaild()
        {
            return Type == null;
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{GetCodeAttribute()?.DxfCode} = {Code}";
    }
}

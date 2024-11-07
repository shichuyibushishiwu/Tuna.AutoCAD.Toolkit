using Autodesk.AutoCAD.DatabaseServices;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter.Tests;

internal class ClassFilterTests
{
    [TestCase(typeof(Arc), "ARC")]
    [TestCase(typeof(AttributeDefinition), "ATTDEF")]
    [TestCase(typeof(AttributeReference), "ATTRIB")]
    [TestCase(typeof(Body), "BODY")]
    [TestCase(typeof(Circle), "CIRCLE")]
    [TestCase(typeof(Dimension), "DIMENSION")]
    [TestCase(typeof(DBText), "TEXT")]
    [TestCase(typeof(Ellipse), "ELLIPSE")]
    [TestCase(typeof(Hatch), "HATCH")]
    [TestCase(typeof(Helix), "HELIX")]
    [TestCase(typeof(Image), "IMAGE")]
    [TestCase(typeof(BlockReference), "INSERT")]
    [TestCase(typeof(Leader), "LEADER")]
    [TestCase(typeof(Light), "LIGHT")]
    [TestCase(typeof(Line), "LINE")]
    [TestCase(typeof(Polyline), "LWPOLYLINE")]
    [TestCase(typeof(MLeader), "MLEADER")]
    [TestCase(typeof(Mline), "MLINE")]
    [TestCase(typeof(MText), "MTEXT")]
    [TestCase(typeof(Ole2Frame), "ONE2FRAME")]
    public void TestClassFilterCode(Type type, string code)
    {
        ClassFilter classFilter = new ClassFilter(type);
        Console.WriteLine(classFilter);

        Assert.That(classFilter.Code, Is.EqualTo(code));
        Assert.That(classFilter.TypeValues.Length, Is.EqualTo(1));
        Assert.That(classFilter.ToString(), Is.EqualTo($"{DxfCode.Start} = {code}"));
    }

    [Test]
    public void TestNullTypeThrowException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            ClassFilter classFilter = new ClassFilter(default);
        });
    }

    [Test]
    public void TestInvalidTypeThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ClassFilter classFilter = new ClassFilter(typeof(int));
        });
    }
}

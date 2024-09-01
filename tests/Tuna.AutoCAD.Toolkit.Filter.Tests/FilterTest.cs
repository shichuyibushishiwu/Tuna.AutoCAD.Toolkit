using Autodesk.AutoCAD.DatabaseServices;
using System.Diagnostics;

namespace Tuna.AutoCAD.Toolkit.Filter.Tests;

public class FilterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ClassTest()
    {
        ClassFilter classFilter = new ClassFilter(typeof(MLeader));
        Console.WriteLine(classFilter);
        Assert.That(classFilter.TypeValues.Length, Is.EqualTo(1));
    }

    [Test]
    public void LayerTest()
    {
        LayerFilter layerFilter = new LayerFilter("Wall");
        Console.WriteLine(layerFilter);
        Assert.Pass();
    }


    [Test]
    public void LogicalAndTest()
    {
        ClassFilter classFilter = new ClassFilter(typeof(MLeader));
        LayerFilter textCLass = new LayerFilter ("Wall");
        LogicalAndFilter logicalAndFilter = new LogicalAndFilter(classFilter, textCLass);
        Console.WriteLine(logicalAndFilter);
      

        Assert.That(logicalAndFilter.TypeValues.Length, Is.EqualTo(4));
    }

    [Test]
    public void LogicalOrTest()
    {
        ClassFilter classFilter = new ClassFilter(typeof(MLeader));
        ClassFilter textCLass = new ClassFilter(typeof(DBText));
        LogicalOrFilter logicalAndFilter = new LogicalOrFilter(classFilter, textCLass);
        Console.WriteLine(logicalAndFilter);

        Assert.Pass();
    }

    [Test]
    public void CompositionalLogicalTest()
    {
        ClassFilter classFilter = new ClassFilter(typeof(MLeader));

        LogicalOrFilter logicalOrFilter = new LogicalOrFilter(new LayerFilter("Wall"), new LayerFilter("Windows"));
        LogicalAndFilter logicalAndFilter = new LogicalAndFilter(classFilter, logicalOrFilter);
        Console.WriteLine(logicalAndFilter);

        Assert.Pass();
    }
}
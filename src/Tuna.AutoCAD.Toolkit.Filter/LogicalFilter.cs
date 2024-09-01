using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

/// <summary>
/// A base class of logical filter
/// </summary>
public abstract class LogicalFilter : FilterBase, IEnumerable<FilterBase>
{
    /// <summary>
    /// Be included in the filter
    /// </summary>
    protected FilterBase[] Filters { get; set; } = default!;

    /// <summary>
    /// Defined a logical filter
    /// </summary>
    /// <param name="logicalCode"></param>
    /// <param name="filters"></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected LogicalFilter(string logicalCode, FilterBase[] filters)
    {
        if (filters == null)
        {
            throw new ArgumentNullException("filters can not be null");
        }

        LogicalCode = logicalCode;
        Filters = filters;

        List<TypedValue> typedValues = new List<TypedValue>();

        typedValues.Add(new TypedValue(AcadFilterTypeCode.Operator, $"<{logicalCode}"));
        typedValues.AddRange(filters.SelectMany(f => f.TypeValues));
        typedValues.Add(new TypedValue(AcadFilterTypeCode.Operator, $"{logicalCode}>"));

        TypeValues = typedValues.ToArray();
    }

    /// <summary>
    /// Logical code
    /// </summary>
    protected string LogicalCode { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        Type type = this.GetType();
        FilterDxfCodeAttribute? attribute = type.GetCustomAttribute<FilterDxfCodeAttribute>();
        if (attribute == null)
        {
            return $"{type} not added {typeof(FilterDxfCodeAttribute)}";
        }

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"<{LogicalCode}");
        foreach (var filter in Filters)
        {
            stringBuilder.AppendLine($"{filter}");
        }
        stringBuilder.Append($"{LogicalCode}>");
        return stringBuilder.ToString();
    }

    public IEnumerator<FilterBase> GetEnumerator()
    {
        foreach (var item in Filters)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

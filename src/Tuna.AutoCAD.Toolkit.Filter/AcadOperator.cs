using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

public enum AcadOperator
{
    /// <summary>
    /// =
    /// </summary>
    Equal,

    /// <summary>
    /// !=
    /// </summary>
    NotEqual,

    /// <summary>
    /// >
    /// </summary>
    GreaterThat,

    /// <summary>
    /// >=
    /// </summary>
    GreaterThatOrEqual
}

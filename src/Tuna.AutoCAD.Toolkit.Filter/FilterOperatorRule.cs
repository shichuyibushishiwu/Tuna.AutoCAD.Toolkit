using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

public  class FilterOperatorRule: FilterRule
{
    public FilterOperatorRule(short parameterCode, AcadOperator acadOperator, int value)
    {
        switch (acadOperator)
        {
            case AcadOperator.Equal:
                OperatorCode = "=";
                break;
            case AcadOperator.NotEqual:
                OperatorCode = "!=";
                break;
            case AcadOperator.GreaterThat:
                OperatorCode = ">";
                break;
            default:
                OperatorCode = "*";
                break;
        }


    }

    public string OperatorCode { get; set; }
}

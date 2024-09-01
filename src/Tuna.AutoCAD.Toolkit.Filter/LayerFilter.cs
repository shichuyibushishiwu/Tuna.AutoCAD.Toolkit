﻿using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.AutoCAD.Toolkit.Filter;

[FilterDxfCode(Autodesk.AutoCAD.DatabaseServices.DxfCode.LayerName)]
public sealed class LayerFilter : FilterBase
{
    public LayerFilter(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("");
        }

        LayerName = name;
        TypeValues = [new TypedValue(ACADFilterTypeCode.LayerName, name)];
    }

    internal string LayerName { get; set; }

    public override string ToString()
    {
        return $"{GetCodeAttribute()?.DxfCode} = {LayerName}";
    }
}
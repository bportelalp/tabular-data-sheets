﻿using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beporsoft.TabularSheets.Helpers
{
    internal static class OpenXMLHelpers
    {
        internal static HexBinaryValue BuildHexBinaryFromColor(System.Drawing.Color color)
            => new HexBinaryValue($"FF{color.R:X}{color.G:X}{color.B:X}");
    }
}

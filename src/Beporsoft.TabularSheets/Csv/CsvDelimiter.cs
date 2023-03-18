﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beporsoft.TabularSheets.Csv
{
    public enum CsvDelimiter
    {
        Semicolon,
        Comma
    }

    public static class CsvDelimiterExtensions
    {
        public static string GetChar(this CsvDelimiter delimiter)
        {
            return delimiter switch
            {
                CsvDelimiter.Comma => ",",
                CsvDelimiter.Semicolon => ";",
                _ => throw new ArgumentException($"Value invalid", nameof(delimiter)),
            };
        }
    }
}

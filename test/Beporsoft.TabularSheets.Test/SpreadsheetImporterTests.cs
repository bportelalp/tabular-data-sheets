﻿using Beporsoft.TabularSheets.Builders;
using Beporsoft.TabularSheets.Test.Helpers;
using Beporsoft.TabularSheets.Test.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beporsoft.TabularSheets.Test
{
    [Category("SpreadsheetImporter")]
    public class SpreadsheetImporterTests
    {
        private readonly TestFilesHandler _filesHandler = new TestFilesHandler("SheetCreation");

        [Test]
        public void Foo()
        {
            var table = Product.GenerateProductSheet(100);

            string path = _filesHandler.BuildPath($"Test{nameof(Foo)}.xlsx");
            table.Create(path);

            table.Clear();
            SpreadsheetImporter<Product> importer = new(table);
            importer.ImportContent(path);

        }
    }
}

﻿using Beporsoft.TabularSheets.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beporsoft.TabularSheets.Test.TestsStyles
{
    internal class TestCellStyling
    {

        [Test]
        public void CheckBorderEqualityContract()
        {
            var border = new BorderStyle();
            Assert.That(border, Is.EqualTo(BorderStyle.Default));

            var borderModified = border;
            border.SetAll(BorderStyle.BorderType.Thin);
            border.Color = System.Drawing.Color.Aquamarine;
            Assert.Multiple(() =>
            {
                Assert.That(borderModified, Is.EqualTo(border));
                Assert.That(borderModified, Is.Not.EqualTo(BorderStyle.Default));
                Assert.That(border, Is.Not.EqualTo(BorderStyle.Default));
            });

            border.SetAll(BorderStyle.BorderType.None);
            border.Color = null;
            Assert.Multiple(() =>
            {
                Assert.That(borderModified, Is.EqualTo(border));
                Assert.That(borderModified, Is.EqualTo(BorderStyle.Default));
                Assert.That(border, Is.EqualTo(BorderStyle.Default));
            });
        }

        [Test]
        public void CheckFontEqualityContract()
        {
            var font = new FontStyle();
            Assert.That(font, Is.EqualTo(FontStyle.Default));

            font.FontSize = 12;
            font.FontFamily = "efa";
            font.FontColor = System.Drawing.Color.Aquamarine;
            Assert.That(font, Is.Not.EqualTo(FontStyle.Default));

            font.FontSize = null;
            font.FontFamily = null;
            font.FontColor = null;
            Assert.That(font, Is.EqualTo(FontStyle.Default));
        }

        [Test]
        public void CheckFillEqualityContract()
        {
            var fill = new FillStyle();
            Assert.That(fill, Is.EqualTo(FillStyle.Default));

            fill.BackgroundColor = System.Drawing.Color.Aquamarine;
            Assert.That(fill, Is.Not.EqualTo(FillStyle.Default));

            fill.BackgroundColor = null;
            Assert.That(fill, Is.EqualTo(FillStyle.Default));
        }

        [Test]
        public void CheckStyleEqualityContract()
        {
            var style = new Style();
            Assert.Multiple(() =>
            {
                Assert.That(style, Is.EqualTo(Style.Default));
                Assert.That(style.Font, Is.EqualTo(FontStyle.Default));
                Assert.That(style.Fill, Is.EqualTo(FillStyle.Default));
                Assert.That(style.Border, Is.EqualTo(BorderStyle.Default));
            });

            // Change one field of one property
            style.Font.FontSize = 0;
            Assert.Multiple(() =>
            {
                Assert.That(style, Is.Not.EqualTo(Style.Default));
                Assert.That(style.Font, Is.Not.EqualTo(FontStyle.Default));
                Assert.That(style.Fill, Is.EqualTo(FillStyle.Default));
                Assert.That(style.Border, Is.EqualTo(BorderStyle.Default));
            });
        }

        [Test]
        [TestCaseSource(nameof(CombineStylesCases))]
        public void CombineStyles(FontStyle style1, FontStyle style2, FontStyle styleExpected)
        {
            FontStyle styleResult = StyleCombiner.Combine(style1, style2);
            Assert.That(styleResult, Is.EqualTo(styleExpected));
        }

        private static IEnumerable<object[]> CombineStylesCases()
        {
            var font1 = new FontStyle();
            var font2 = new FontStyle();
            var fontR = new FontStyle();

            font1.FontSize = 0;
            font2.FontSize = 14;
            fontR.FontSize = 0;
            yield return new object[] { font1, font2, fontR };
            font1.FontSize = null;
            font2.FontSize = 14;
            fontR.FontSize = 14;
            yield return new object[] { font1, font2, fontR };
            font1.FontColor = null;
            font2.FontColor = System.Drawing.Color.AliceBlue;
            fontR.FontColor = System.Drawing.Color.AliceBlue;
            yield return new object[] { font1, font2, fontR };
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization
{
    [TestFixture]
    public class RectangleExtensions_Test
    {
        [TestCaseSource(nameof(TestData))]
        public void Center_ShouldReturnTheCentralPointOfRectangle(Rectangle rectangle, Point expectedCenter)
        {
            var actualCenter = rectangle.Center();

            actualCenter.ShouldBeEquivalentTo(expectedCenter);
        }

        public static IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData(new Rectangle(0, 0, 10, 10), new Point(5, 5));
                yield return new TestCaseData(new Rectangle(-5, -5, 10, 10), new Point(0, 0));
            }
        }
    }
}

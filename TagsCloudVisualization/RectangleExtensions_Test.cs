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
        [TestCaseSource(nameof(Center_TestData))]
        public void Center_ShouldReturnTheCentralPointOfRectangle(Rectangle rectangle, Point expectedCenter)
        {
            var actualCenter = rectangle.Center();

            actualCenter.ShouldBeEquivalentTo(expectedCenter);
        }

        [TestCaseSource(nameof(DistanceTo_TestData))]
        public double DistanceTo_ShouldCalculate_DistanceFromCenterToSpecifiedPoint(Rectangle rectangle, Point point)
        {
            return rectangle.DistanceTo(point);
        }

        public static IEnumerable Center_TestData
        {
            get
            {
                yield return new TestCaseData(new Rectangle(0, 0, 10, 10), new Point(5, 5));
                yield return new TestCaseData(new Rectangle(-5, -5, 10, 10), new Point(0, 0));
            }
        }

        public static IEnumerable DistanceTo_TestData
        {
            get
            {
                yield return new TestCaseData(new Rectangle(0, 0, 10, 10), new Point(20, 20))
                    .Returns(Math.Sqrt(Math.Pow(15, 2) + Math.Pow(15, 2)));

                yield return new TestCaseData(new Rectangle(20, 0, 10, 10), new Point(20, 20))
                    .Returns(Math.Sqrt(Math.Pow(15, 2) + Math.Pow(5, 2)));

                yield return new TestCaseData(new Rectangle(25, 25, 10, 10), new Point(20, 20))
                    .Returns(Math.Sqrt(Math.Pow(10, 2) + Math.Pow(10, 2)));

                yield return new TestCaseData(new Rectangle(15, 25, 10, 10), new Point(20, 20))
                    .Returns(Math.Sqrt(Math.Pow(0, 2) + Math.Pow(10, 2)));

                yield return new TestCaseData(new Rectangle(-10, -10, 10, 10), new Point(20, 20))
                    .Returns(Math.Sqrt(Math.Pow(25, 2) + Math.Pow(25, 2)));

                yield return new TestCaseData(new Rectangle(15, 15, 10, 10), new Point(-5, -5))
                    .Returns(Math.Sqrt(Math.Pow(25, 2) + Math.Pow(25, 2)));
            }
        }
    }
}

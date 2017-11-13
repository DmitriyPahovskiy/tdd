using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization
{
    public class CircularCloudLayouter_Test
    {
        [Test]
        public void PutNextRectangle_ShouldReturnRectangle_WithSpecifiedSize()
        {
            var expectedSize = new Size(10, 10);
            var rectangle = new CircularCloudLayouter(new Point()).PutNextRectangle(expectedSize);

            rectangle.Size.ShouldBeEquivalentTo(expectedSize);
        }

        [Test]
        public void PutNextRectangle_ShouldPutFirstTag_InTheCentre()
        {
            var cloudCentre = new Point(0,0);
            var target = new CircularCloudLayouter(cloudCentre);

            var rectangle = target.PutNextRectangle(new Size(10, 10));

            rectangle.Center().ShouldBeEquivalentTo(cloudCentre);
        }

        [Test]
        public void PutNextRectangle_ShouldKeep_RoundShapeOfCloud()
        {
            // Проверку на "округлость" можно построить путём проверки расстояний от центров прямоугольников до центра облака.
            // В данном случае возникает задача определения максимально возможного расстояния. Для начала можно делать это экспертным способом :)
            
            var cloudCentre = new Point(0, 0);
            var tags = new List<Rectangle>();
            var target = new CircularCloudLayouter(cloudCentre);

            tags.Add(target.PutNextRectangle(new Size(4, 2)));
            tags.Add(target.PutNextRectangle(new Size(3, 1)));
            tags.Add(target.PutNextRectangle(new Size(2, 2)));
            tags.Add(target.PutNextRectangle(new Size(4, 3)));
            tags.Add(target.PutNextRectangle(new Size(4, 2)));
            tags.Add(target.PutNextRectangle(new Size(4, 4)));
            tags.Add(target.PutNextRectangle(new Size(2, 1)));
            tags.Add(target.PutNextRectangle(new Size(5, 2)));

            // предполагая раскладку указанных прямоугольников по спирали начиная с "9 часов", 
            // имеем расстояние от центра облака до самого дальнего центра прямоугольника по Х - 4, по Y - 1, по прямой - 4.123
            tags.Max(r => r.DistanceTo(cloudCentre)).Should().BeLessThan(4.2);
        }

        [Test]
        public void PutNextRectangle_ShouldNotInterfere_NewRectangleWithAnyExisting()
        {
            var cloudCentre = new Point(0, 0);
            var target = new CircularCloudLayouter(cloudCentre);

            var rectangle1 = target.PutNextRectangle(new Size(4, 2));
            var rectangle2 = target.PutNextRectangle(new Size(3, 1));

            rectangle2.IntersectsWith(rectangle1).Should().BeFalse();
        }
    }
    
}

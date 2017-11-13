using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
        public void PutNextRectangle_ShouldNotInterfere_NewRectangleWithAnyExisting()
        {
            var cloudCentre = new Point(0, 0);
            var target = new CircularCloudLayouter(cloudCentre);

            var rectangle1 = target.PutNextRectangle(new Size(4, 2));
            var rectangle2 = target.PutNextRectangle(new Size(3, 1));

            rectangle2.IntersectsWith(rectangle1).Should().BeFalse();
        }

        [Test]
        public void PutNextRectangle_ShouldKeep_RoundShapeOfCloud()
        {
            // Проверку на "округлость" можно построить путём проверки расстояний от центров прямоугольников до центра облака.
            // В данном случае возникает задача определения максимально возможного расстояния. Для начала можно делать это экспертным способом :)
            
            var cloudCentre = new Point(300, 300);
            var tags = new List<Rectangle>();
            var target = new CircularCloudLayouter(cloudCentre);

            var random = new Random();
            
            for(int i = 0;i<10;i++)
                tags.Add(target.PutNextRectangle(new Size(random.Next(20,40), random.Next(10,20))));

            DrawAndSaveCloud(tags);
            
            tags.Max(r => r.DistanceTo(cloudCentre)).Should().BeLessThan(161); //??
        }

        private void DrawAndSaveCloud(List<Rectangle> tags)
        {
            var width = 600;
            var height = 600;

            var bm = new Bitmap(width, height);
            var g = Graphics.FromImage(bm);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle { X = 0, Y = 0, Width = width, Height = height });

            g.DrawRectangles(new Pen(Color.Blue), tags.ToArray());

            Directory.CreateDirectory($"c:/temp");

            g.Save(); 
            bm.Save($"c:/temp/cloud_{DateTime.Now:yyMMdd_HHmmss}.png");
        }
    }
    
}

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
        public void PutNextRectangle_ShouldCreateRectangle_WithSpecifiedSize()
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

            target.PutNextRectangle(new Size(10, 10));

            var rectangle = target.Tags[0];
            rectangle.Center().ShouldBeEquivalentTo(cloudCentre);
        }
    }
    
}

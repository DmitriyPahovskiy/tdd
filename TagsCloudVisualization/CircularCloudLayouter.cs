using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public class CircularCloudLayouter
    {
        private readonly Point center;

        private readonly List<Rectangle> tags  = new List<Rectangle>();

        public CircularCloudLayouter(Point center)
        {
            this.center = center;
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            var rectangle = new Rectangle(new Point(center.X - rectangleSize.Width/2, center.Y - rectangleSize.Height/2), rectangleSize);
            tags.Add(rectangle);
            return rectangle;
        }
    }
}

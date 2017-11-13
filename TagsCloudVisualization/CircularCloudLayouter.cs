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
        private readonly IPositioner positioner;


        public CircularCloudLayouter(Point center)
        {
            this.center = center;
            positioner = new ArchimedeanPositioner(1, 1); 
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            var rectangle = CreateRectangleAtCenter(rectangleSize);

            MoveToNextPosition(ref rectangle);

            CompactToCenter(ref rectangle);

            tags.Add(rectangle);
            
            return rectangle;
        }

        private Rectangle CreateRectangleAtCenter(Size rectangleSize)
        {
            return new Rectangle(new Point(center.X - rectangleSize.Width / 2, center.Y - rectangleSize.Height / 2), rectangleSize);
        }

        private void MoveToNextPosition(ref Rectangle rectangle)
        {
            Rectangle copyRectangle;
            do
            {
                int dx, dy;
                positioner.NextPosition(out dx, out dy);
                rectangle.X += dx;
                rectangle.Y += dy;
                copyRectangle = rectangle;
            }
            while (tags.Any(t => t.IntersectsWith(copyRectangle)));
        }

        private void CompactToCenter(ref Rectangle rectangle)
        {
            // TODO: implement
        }
    }
}

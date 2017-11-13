using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Метод вычисляет ближайшую к центру прямоугольника точку с целыми координатами.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(rectangle.Left + rectangle.Width / 2,
                rectangle.Top + rectangle.Height / 2);
        }

        /// <summary>
        /// Метод считает расстояние от центра прямоугольника до указанной точки.
        /// </summary>
        public static double DistanceTo(this Rectangle rectangle, Point point)
        {
            var center = rectangle.Center();
            return Math.Sqrt(Math.Pow(Math.Abs(point.X - center.X), 2) + Math.Pow(Math.Abs(point.Y - center.Y), 2));
        }
    }
}

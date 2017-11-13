using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public class ArchimedeanPositioner : IPositioner
    {
        private int factor = 0;
        private int angle = 0;

        public void NextPosition(out int x, out int y)
        {
            x = (int) (factor * angle * Math.Cos(angle));
            y = (int) (factor * angle * Math.Sin(angle));

            factor++;
            angle = (++angle) % 361 + 1;
        }
    }
}

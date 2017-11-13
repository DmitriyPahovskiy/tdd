using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public class ArchimedeanPositioner : IPositioner
    {
        private readonly double factorDelta = 1;
        private readonly double spiralPower = 0.5;

        private double factor = 0;
        private int angle = 0;

        public ArchimedeanPositioner(double factorDelta, double spiralPower)
        {
            this.factorDelta = factorDelta;
            this.spiralPower = spiralPower;
        }

        public void NextPosition(out int x, out int y)
        {
            x = (int) (factor * Math.Pow(angle, spiralPower) * Math.Cos(angle));
            y = (int) (factor * Math.Pow(angle, spiralPower) * Math.Sin(angle));

            factor += factorDelta;
            angle = (++angle) % 361 + 1;
        }
    }
}

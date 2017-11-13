using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public interface IPositioner
    {
        void NextPosition(out int x, out int y);
    }
}

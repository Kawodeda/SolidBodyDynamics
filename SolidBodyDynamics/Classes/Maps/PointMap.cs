using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBodyDynamics
{
    public class PointMap
    {
        public Vector2[] Map { get; }

        public PointMap(IEnumerable<Vector2> points)
        {
            Map = points.ToArray();
        }

        public PointMap(PointMap pointMap)
        {
            pointMap.Map.CopyTo(Map, 0);
        }
    }
}

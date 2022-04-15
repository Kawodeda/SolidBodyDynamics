using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBodyDynamics
{
    public class MaterialPointMap : PointMap
    {
        public MaterialPoint[] Points { get; }

        public MaterialPointMap(IEnumerable<MaterialPoint> points, IEnumerable<Vector2> positions) : base(positions)
        {
            if(points.Count() < positions.Count())
            {
                Points = new MaterialPoint[positions.Count()];
                points.ToList().CopyTo(Points);
            }
            else
            {
                Points = points.ToArray();
            }  
        }

        public MaterialPointMap(MaterialPointMap materialPointMap) : base(materialPointMap.Map)
        {
            Points = new MaterialPoint[materialPointMap.Points.Length];
            materialPointMap.Points.CopyTo(Points, 0);
        }
    }
}

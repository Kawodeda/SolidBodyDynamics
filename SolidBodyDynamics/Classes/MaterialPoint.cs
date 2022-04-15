using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBodyDynamics
{
    public class MaterialPoint
    {
        public Vector2 Pos { get; private set; }
        public float m { get; }

        public MaterialPoint(float _m) : this(0, 0, _m) { }

        public MaterialPoint(float _x, float _y, float _m)
        {
            Pos = new Vector2(_x, _y);
            m = _m;
        }

        public MaterialPoint(Vector2 position, float _m)
        {
            Pos = new Vector2(position);
            m = _m;
        }

        public void UpdatePosition(float _x, float _y)
        {
            Pos.x = _x;
            Pos.y = _y;
        }

        public void UpdatePosition(Vector2 point)
        {
            Pos.x = point.x;
            Pos.y = point.y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBodyDynamics
{
    public class Vector2
    {
        public float x { get; }
        public float y { get; }

        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public Vector2(Vector2 position)
        {
            x = position.x;
            y = position.y;
        }

        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, float scalar) => new Vector2(a.x * scalar, a.y * scalar);
        public static Vector2 operator *(float scalar, Vector2 a) => new Vector2(a.x * scalar, a.y * scalar);
        public static Vector2 operator /(Vector2 a, float denominator) => new Vector2(a.x / denominator, a.y / denominator);
        public static bool operator !=(Vector2 a, Vector2 b) => (a.x != b.x || a.y != b.y);
        public static bool operator ==(Vector2 a, Vector2 b) => (a.x == b.x && a.y == b.y);
    }
}

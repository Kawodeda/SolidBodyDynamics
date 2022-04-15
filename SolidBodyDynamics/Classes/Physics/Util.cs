using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBodyDynamics.Classes.Physics
{
    public class Util
    {
        public const float PI = (float)Math.PI;

        public static Vector2 ApplyRotation(Vector2 point, float angle)
        {
            float x = (float)(point.x * Math.Cos(angle) - point.y * Math.Sin(angle)),
                    y = (float)(point.x * Math.Sin(angle) + point.y * Math.Cos(angle));

            return new Vector2(x, y);
        }

        public static float GetMass(SolidBody solidBody)
        {
            return solidBody.Map.Points.Sum(point => point.m);
        }

        public static Vector2 GetMassCenter(SolidBody solidBody)
        {
            Vector2 massCenter = new Vector2(0, 0);

            for(int i = 0; i < solidBody.Map.Points.Length; i++)
            {
                massCenter += solidBody.Map.Points[i].m * solidBody.Map.Map[i];
                var a = massCenter.x;
                var b = massCenter.y;
            }
            var c = massCenter.x;
            var d = massCenter.y;
            massCenter /= solidBody.Mass;
            var e = massCenter.x;
            var f = massCenter.y;

            return massCenter;
        }

        public static void UpdatePointsPositions(SolidBody solidBody)
        {
            for(int i = 0; i < solidBody.Map.Points.Length; i++)
            {
                solidBody.Map.Points[i].UpdatePosition(
                    solidBody.Pos + solidBody.MassCenterPos + ApplyRotation(solidBody.Map.Map[i] - solidBody.MassCenterPos, solidBody.Angle));
            }
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            float dx = a.x - b.x,
                    dy = a.y - b.y;

            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}

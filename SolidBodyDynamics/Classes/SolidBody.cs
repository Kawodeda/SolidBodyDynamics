using SolidBodyDynamics.Interfaces;
using SolidBodyDynamics.Classes.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBodyDynamics
{
    public class SolidBody : IMovable, IRotatable
    {
        public Vector2 Pos { get; set; }
        public Vector2 MassCenterPos { get; }
        public float Mass { get; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public float Angle { get; set; }
        public float Omega { get; set; }
        public float Epsilon { get; set; }
        public float I { get; }
        public MaterialPointMap Map { get; }

        public SolidBody(MaterialPointMap map, Vector2 position)
        {
            Pos = new Vector2(position);
            Map = new MaterialPointMap(map);

            Mass = Util.GetMass(this);
            MassCenterPos = Util.GetMassCenter(this);

            Angle = 0;
            //Angle = Util.PI / 1;
            Velocity = new Vector2(0.5f, 0);
            Acceleration = new Vector2(0, 0.01f);
            Omega = 0;
            Epsilon = 0.0001f;
            I = 0;

            Util.UpdatePointsPositions(this);
        }
    }
}

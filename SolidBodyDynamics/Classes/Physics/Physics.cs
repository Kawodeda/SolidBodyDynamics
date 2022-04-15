using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBodyDynamics.Classes.Physics
{
    public class Physics
    {
        public static void Run(SolidBody solidBody)
        {
            CalculateOmega(solidBody);
            CalculateVelocity(solidBody);
            CalculatePosition(solidBody);
        }

        private static void CalculatePosition(SolidBody solidBody)
        {
            solidBody.Pos += solidBody.Velocity;
            solidBody.Angle += solidBody.Omega;
            Util.UpdatePointsPositions(solidBody);
        }

        private static void CalculateVelocity(SolidBody solidBody)
        {
            solidBody.Velocity += solidBody.Acceleration;
        }

        private static void CalculateOmega(SolidBody solidBody)
        {
            solidBody.Omega += solidBody.Epsilon;
        }
    }
}

using System;

namespace SolidBodyDynamics.Interfaces
{
    public interface IRotatable
    {
        float Angle { get; set; }
        float Omega { get; set; }
        float Epsilon { get; set; }
        float I { get;}
    }
}

using System;

namespace SolidBodyDynamics.Interfaces
{
    public interface IMovable
    {
        Vector2 Pos { get; set; }
        Vector2 Velocity { get;  set; }
        Vector2 Acceleration { get; set; }
    }
}

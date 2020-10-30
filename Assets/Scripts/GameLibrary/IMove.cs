using UnityEngine;

namespace GameLibrary
{
    public interface IMove
    {
        float ForwardAcceleration { get; set; }
        float SideAcceleration { get; set; }
        float Speed { get; set; }
        Transform DirectionObject { set; }
    }
}
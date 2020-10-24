using UnityEngine;

namespace GameLibrary
{
    internal interface IMove
    {
        float ForwardAcceleration { get; set; }
        float SideAcceleration { get; set; }
        float Speed { get; set; }
    }
}
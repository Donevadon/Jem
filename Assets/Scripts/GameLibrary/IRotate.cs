using UnityEngine;

namespace GameLibrary
{
    internal interface IRotate
    {
        float Speed { get; set; }
        float UpRotate { set; }
        float SideRotate { set; }
        Vector2 MaxRotation { get; set; }
        Vector2 MinRotation { get; set; }
    }
}
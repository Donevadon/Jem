using GameLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMove : MonoBehaviour, IMove
{
    public float ForwardAcceleration { get; set; }
    public float SideAcceleration { get; set; }
    public float Speed { get; set; }
    public Transform DirectionObject { private get; set; }
}

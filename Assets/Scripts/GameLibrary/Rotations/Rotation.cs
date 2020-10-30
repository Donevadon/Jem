using GameLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour, IRotate
{
    private float speed = 5;
    public float Speed { get => speed; set => speed = value; }
    private float mouseY;
    public float UpRotate { set => mouseY = Mathf.Clamp(GetAngle(mouseY) - value * speed,MinRotation.x,MaxRotation.x); }
    private float mouseX;
    public float SideRotate { set => mouseX = Mathf.Clamp(GetAngle(mouseX) + value * speed,MinRotation.y,MaxRotation.y); }
    public Vector2 MaxRotation { get; set; } = new Vector2(90, 361);
    public Vector2 MinRotation { get; set; } = new Vector2(-40,-361);

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }

    private float GetAngle(float angle)
    {
        if (angle < -360) angle += 360;
        else if(angle > 360) angle -= 360;
        return angle;
    }
}

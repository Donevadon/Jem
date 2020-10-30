using GameLibrary;
using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeBehavior 
{
    void ChangeMove(IMove move);
    void ChangeShoot(IShoot shoot);
    void ChangePointer();
    void Move(Vector3 position);
}

public class Rifle : MonoBehaviour, ISubjectInteraction
{
    public InteractionEntity Type => InteractionEntity.Rifle;

    private IShoot shoot;

    public bool IsActive { get; private set; } = true;

    private void Awake()
    {
        shoot = GetComponent<IShoot>();
    }

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        IChangeBehavior behavior = sender as IChangeBehavior;
        behavior.ChangePointer();
        behavior.ChangeMove(new RifleMove());
        behavior.ChangeShoot(shoot);
        MonoBehaviour behaviour = sender as MonoBehaviour;
        IRotate rotate = behaviour.GetComponent<IRotate>();
        rotate.MaxRotation = new Vector2(40,50);
        rotate.MinRotation = new Vector2(-40,-50);
        behaviour.transform.parent = null;
        behavior.Move( new Vector3(1.25f, 2.654659f, 6));
        Spawn.StartAllSpawn();
    }
}

using GameLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour,IZombi
{
    public GameObject Target;
    private IMove movement;
    private IRotate rotate;
    private Animator animator;

    public bool IsDead { get; private set; } = false;

    private void Awake()
    {
        movement = GetComponent<IMove>();
        animator = GetComponent<Animator>();
        movement.DirectionObject = transform;
    }

    private void Start()
    {
        movement.ForwardAcceleration = 1;
        movement.Speed = 3;
        Target = GameObject.FindGameObjectWithTag("Home");
    }

    private void FixedUpdate()
    {
        transform.LookAt(Target.transform);
    }

    public void Dead()
    {
        IsDead = true;
        movement.ForwardAcceleration = 0;
        animator.SetBool("Dead", true);
        Destroy(gameObject, 3);
    }


}

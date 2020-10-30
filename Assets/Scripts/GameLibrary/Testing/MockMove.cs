using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary.Testing
{
    internal class MockMove : MonoBehaviour, IMove
    {
        [SerializeField]private float speed;
        public float Speed { get => speed; set => speed = value; }
        public float ForwardAcceleration { get; set; }
        public float SideAcceleration { get; set; }
        public Transform DirectionObject { set => throw new System.NotImplementedException(); }

        private MockMove()
        {

        }
        internal MockMove(float speed)
        {
            Speed = speed;
        }
        private void Move()
        {
            transform.Translate(ForwardAcceleration * Speed * Vector3.forward);
            transform.Translate(SideAcceleration * Speed * Vector3.right);
        }
        private void FixedUpdate()
        {
            Move();
        }
    }
}
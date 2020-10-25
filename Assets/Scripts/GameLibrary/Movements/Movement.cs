using GameLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary.Movement
{
    public class Movement : MonoBehaviour, IMove
    {
        private CharacterController controller;

        public float ForwardAcceleration { get; set; }
        public float SideAcceleration { get; set; }
        [SerializeField] private float speed = 5;
        public float Speed { get => speed; set => speed = value; }

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        #region Движение
        private void Move()
        {
            controller.Move(GetPosition() * Time.deltaTime);

        }

        private Vector3 GetPosition()
        {
            Vector3 position = MoveForward() + MoveSide();
            Vector3 positionWithGravity = PullGravity(position);
            return positionWithGravity;
        }

        private Vector3 MoveForward()
        {
            return transform.TransformDirection(Vector3.forward) * ForwardAcceleration * Speed;
        }

        private Vector3 MoveSide()
        {
            return transform.TransformDirection(Vector3.right) * SideAcceleration * Speed;
        }
        private Vector3 PullGravity(Vector3 position)
        {
            position.y = 0;
            return position;
        }
        #endregion
    }
}
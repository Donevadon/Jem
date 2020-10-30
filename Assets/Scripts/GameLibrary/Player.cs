using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GameLibrary
{
    public interface IShoot
    {
        void Shoot();
    }
    public class Player : MonoBehaviour,IChangeBehavior
    {
        private IMove movement;
        private IRotate rotation;
        private IInteraction interaction;
        private IShoot shoot;
        public GameObject Pointer;
        public GameObject RiflePointer;
        public AudioClip FinalClip;

        private void Awake()
        {
            try
            {
                movement = GetComponentInParent<IMove>() ?? throw new System.Exception("Компонент передвижения не установлен");
                movement.DirectionObject = Camera.main.transform;
            }catch(Exception ex)
            {
                print(ex.Message);
            }
            try
            {
                rotation = GetComponent<IRotate>() ?? throw new System.Exception("Компонент вращения не установлен");
            }catch(Exception ex)
            {
                print(ex.Message);
            }

            try
            {
                interaction = GetComponent<IInteraction>() ?? throw new System.Exception("Компонент взаимодействия отсутствует");
            }catch(Exception ex)
            {
                print(ex.Message);
            }
        }
        #region Управление
        private void Update()
        {
            if(movement != null && rotation != null)
                Control();
        }
        private void Control()
        {
            movement.ForwardAcceleration = Input.GetAxis("Vertical");
            movement.SideAcceleration = Input.GetAxis("Horizontal");
            rotation.UpRotate = Input.GetAxis("Mouse Y");
            rotation.SideRotate = Input.GetAxis("Mouse X");
            if (Input.GetButtonDown("Use"))
            {
                interaction.InvokeInteract(this);
            }
            if (Input.GetMouseButtonDown(0))
            {
                shoot?.Shoot();
            }
        }
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            interaction.StartSearchingInteractiveObject(other);
        }

        private void OnTriggerExit(Collider other)
        {
            interaction.StopSearch(other);
        }

        public void ChangeMove(IMove move)
        {
            movement.ForwardAcceleration = 0;
            movement.SideAcceleration = 0;
            movement = move;
        }

        public void ChangeRotate(IRotate rotate)
        {
            rotation = rotate;
        }

        public void ChangePointer()
        {
            Pointer.SetActive(!Pointer.activeSelf);
            RiflePointer.SetActive(!RiflePointer.activeSelf);
        }

        public void Move(Vector3 position)
        {
            StartCoroutine(Moving(position));
        }

        private IEnumerator Moving(Vector3 position)
        {
            while(transform.position != position)
            {
                transform.position = Vector3.MoveTowards(transform.position, position, 3 * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }

        public void ChangeShoot(IShoot shoot)
        {
            this.shoot = shoot;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GameLibrary
{
    public class Player : MonoBehaviour
    {
        private IMove movement;
        private IRotate rotation;
        private IInteraction interaction;

        private void Awake()
        {
            try
            {
                movement = GetComponent<IMove>() ?? throw new System.Exception("Компонент передвижения не установлен");
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
            Control();
        }
        private void Control()
        {
            movement.ForwardAcceleration = Input.GetAxis("Vertical");
            movement.SideAcceleration = Input.GetAxis("Horizontal");
            rotation.UpRotate = Input.GetAxis("Mouse Y");
            rotation.SideRotate = Input.GetAxis("Mouse X");
            if (Input.GetButton("Use"))
            {
                interaction.InvokeInteract(this);
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
    }
}
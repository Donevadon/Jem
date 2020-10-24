using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary
{
    public class Player : MonoBehaviour
    {
        private IMove movement;
        private IRotate rotation;

        private void Awake()
        {
            movement = GetComponent<IMove>() ?? throw new System.Exception("Компонент передвижения не установлен");
            rotation = GetComponent<IRotate>() ?? throw new System.Exception("Компонент вращения не установлен");
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
        }
        #endregion
    }
}
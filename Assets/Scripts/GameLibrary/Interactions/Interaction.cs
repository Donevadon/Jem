using System;
using System.Collections.Generic;
using UnityEngine;
using Display = GameLibrary.Interactions.GraphicDisplay.Display;

namespace GameLibrary.Interactions
{
    internal interface IGraphicDisplay
    {
        void ShowInteractPrepared();
        void CleanUpInteractPrepared();
    }
    public class Interaction : MonoBehaviour, IInteraction, IIntegrable
    {
        private Queue<Task> tasks;
        private IPointerToInteractObject pointer;
        private IGraphicDisplay display;
        private Coroutine search;

        private event EventHandler interactPressed;
        public event EventHandler Interact_Pressed
        {
            add 
            {
                interactPressed = value;
            }
            remove
            {
                interactPressed = null;
            }
        }

        private void Awake()
        {
            CreateTaskList();
        }

        private void CreateTaskList()
        {
            tasks = new Queue<Task>();
            tasks.Enqueue(new Task(InteractionEntity.MusicPlayer));
            tasks.Enqueue(new Task(InteractionEntity.CoffeeMachine));
            tasks.Enqueue(new Task(InteractionEntity.Cup));
            tasks.Enqueue(new Task(InteractionEntity.Window));
            tasks.Enqueue(new Task(InteractionEntity.Flowers));
            tasks.Enqueue(new Task(InteractionEntity.GuitarCase));
            tasks.Enqueue(new Task(InteractionEntity.RifleInCase));
            tasks.Enqueue(new Task(InteractionEntity.Rifle));
        }
        //TODO:Отделить работу с тасками

        public void StartSearchingInteractiveObject(Collider collider)
        {
            if (collider.GetComponent<ISubjectInteraction>() != null)
            {
                pointer = new PointerToInteractiveObject(this);
                pointer.Interact_Prepared += PointerInteractPrepared;
                pointer.Interact_NotPrepared += PointerInteractNotPrepared;
                search = StartCoroutine(pointer.FindInteractObject(tasks.Peek()));
            }
        }

        private void PointerInteractNotPrepared(object sender, EventArgs e)
        {
            display = Display.GetInstance();
            display.CleanUpInteractPrepared();
        }

        private void PointerInteractPrepared(object sender, EventArgs e)
        {
            display = Display.GetInstance();
            display.ShowInteractPrepared();
        }

        public void StopSearch(Collider collider)
        {
            if (collider.GetComponent<ISubjectInteraction>() != null)
            {
                pointer.Interact_Prepared -= PointerInteractPrepared;
                pointer.Interact_NotPrepared -= PointerInteractNotPrepared;
                StopCoroutine(search);
                PointerInteractNotPrepared(this,null);
                pointer = null;
            }
        }

        public void InvokeInteract(object sender)
        {
            interactPressed?.Invoke(sender,null);
        }

        public void ResetEvent()
        {
            interactPressed = null;
        }
    }
}
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
        void UpdateTask(Task task);
    }
    internal interface ITasksManager
    {
        Task Peek();
        Task Dequeue();
    }
    public class Interaction : MonoBehaviour, IInteraction, IIntegrable
    {
        private IPointerToInteractObject pointer;
        private ITasksManager tasksManager = new TaskManager();
        private IGraphicDisplay display;
        private ISubjectInteraction ActiveObject;
        private bool isActive;


        private Coroutine search;

        private event EventHandler interactPressed;
        public event EventHandler Interact_Pressed
        {
            add 
            {
                interactPressed = value;
                interactPressed += (x, y) =>
                {
                    tasksManager.Dequeue();
                    display.UpdateTask(tasksManager.Peek());
                    pointer.Task = tasksManager.Peek();
                };
            }
            remove
            {
                interactPressed = null;
            }
        }

        private void Awake()
        {
            pointer = new PointerToInteractiveObject(this);
        }

        private void Start()
        {
            display = Display.GetInstance();
            display.UpdateTask(tasksManager.Peek());
            pointer.Task = tasksManager.Peek();

        }

        public void StartSearchingInteractiveObject(Collider collider)
        {
            ISubjectInteraction obj = collider?.GetComponent<ISubjectInteraction>();
            if (obj != null && isActive == false)
            {
                isActive = true;
                ActiveObject = obj;
                pointer.Interact_Prepared += PointerInteractPrepared;
                pointer.Interact_NotPrepared += PointerInteractNotPrepared;
                search = StartCoroutine(pointer.FindInteractObject()); 
            }
        }

        private void PointerInteractNotPrepared(object sender, EventArgs e)
        {
            display.CleanUpInteractPrepared();
        }

        private void PointerInteractPrepared(object sender, EventArgs e)
        {
            display.ShowInteractPrepared();
        }

        public void StopSearch(Collider collider)
        {
            if (collider.GetComponent<ISubjectInteraction>() == ActiveObject)
            {
                pointer.Interact_Prepared -= PointerInteractPrepared;
                pointer.Interact_NotPrepared -= PointerInteractNotPrepared;
                StopCoroutine(search);
                isActive = false;
                PointerInteractNotPrepared(this,null);
            }
        }

        public void InvokeInteract(object sender)
        {
            interactPressed?.Invoke(sender,null);
            interactPressed = null;
        }

        public void ResetEvent()
        {
            interactPressed = null;
        }
    }
}
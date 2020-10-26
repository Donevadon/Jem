using GameLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;


namespace GameLibrary.Interactions
{
    public interface IFindInteractionObject
    {
        ISubjectInteraction GetInteractObject();
    }
    public class Interaction : MonoBehaviour, IInteraction, IInteractEvent
    {
        public bool IsSubscriber => interactPressed != null;

        private Queue<Task> tasks;
        private float rayDistance = 0.5f;
        private ISubjectInteraction selectSubject = null;
        private IFindInteractionObject findInteraction;

        private event EventHandler interactPressed;
        public event EventHandler InteractPressed 
        {
            add 
            {
                interactPressed = value;
            }
            remove
            {
                interactPressed -= value;
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

        public void IdentifyFoundObject(Collider o)
        {
            try
            {
                ISubjectInteraction foundObject = o?.GetComponent<ISubjectInteraction>() ?? throw new NotFoundInteractExeption();
                if(foundObject.Type == tasks.Peek().interactionEntity)
                {
                    ISubjectInteraction foundObjectWithRay = findInteraction.GetInteractObject();

                }
            }
            catch (NotFoundInteractExeption ex)
            {
                return;
            }
        }

        private IEnumerator FindObject()
        {
            RaycastHit hit;
            while (true)
            {
                //Запуск луча из центра экрана
                var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                ISubjectInteraction subject = null;
                if (Physics.Raycast(new Ray(ray.origin, ray.direction * rayDistance), out hit))
                {
                    subject = hit.collider.gameObject?.GetComponent<ISubjectInteraction>();
                    if (subject != null && (subject != selectSubject || !InteractEvent.IsSubscriber))
                    {
                        //При наличии нужного таргета
                        InteractEvent.InteractPressed += EnterHadler;
                        selectSubject = subject;
                    }
                    else if (subject is null && InteractEvent.IsSubscriber)
                    {
                        //При наличии стороннего таргета, и наличии подписки
                        InteractEvent.InteractPressed -= EnterHadler;
                    }
                }
                else if (InteractEvent.IsSubscriber)
                {
                    //При отсутствии таргета ,но наличии подписчиков
                    InteractEvent.InteractPressed -= EnterHadler;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.GetComponent<ISubjectInteraction>() != null)
            {
                findInteraction.GetInteractObject();
            }
        }
    }
}
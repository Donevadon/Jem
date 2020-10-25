using GameLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;



public class Interaction : MonoBehaviour, IInteraction
{
    public IInteractEvent InteractEvent { private get; set; }

    private float rayDistance = 0.5f;
    private ISubjectInteraction selectSubject = null;
    private Coroutine Find;

    public void FindInteractObject(Collider o)
    {
        if (o.gameObject?.GetComponent<ISubjectInteraction>() != null)
        {
            Find = StartCoroutine(FindObject());
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
            if (Physics.Raycast(new Ray(ray.origin,ray.direction * rayDistance),out hit))
            {
                subject = hit.collider.gameObject?.GetComponent<ISubjectInteraction>();
                if(subject != null && (subject != selectSubject || !InteractEvent.IsSubscriber)) 
                {
                    //При наличии нужного таргета
                    InteractEvent.InteractPressed += EnterHadler;
                    selectSubject = subject;
                }else if(subject is null && InteractEvent.IsSubscriber)
                {
                    //При наличии стороннего таргета, и наличии подписки
                    InteractEvent.InteractPressed -= EnterHadler;
                }
            }else if (InteractEvent.IsSubscriber)
            {
                //При отсутствии таргета ,но наличии подписчиков
                InteractEvent.InteractPressed -= EnterHadler;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void EnterHadler(object sender, EventArgs a)
    {
        selectSubject.Interact();
    }

    public void RemoveInteractObject(Collider o)
    {
        if (o.gameObject.GetComponent<ISubjectInteraction>() != null)
        {
            InteractEvent.InteractPressed -= EnterHadler;
            selectSubject = null;
            StopCoroutine(Find);
        }
    }
}

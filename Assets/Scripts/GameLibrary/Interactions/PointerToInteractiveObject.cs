using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLibrary.Interactions
{
    internal class PointerToInteractiveObject : IPointerToInteractObject
    {
        private IIntegrable integrable;
        private Camera camera = Camera.main;
        public event EventHandler Interact_Prepared;
        public event EventHandler Interact_NotPrepared;

        private PointerToInteractiveObject() { }
        public PointerToInteractiveObject(IIntegrable integrable)
        {
            this.integrable = integrable;
        }

        public IEnumerator FindInteractObject(Task task)
        {
            RaycastHit hit;
            while (true)
            {
                Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if(Physics.Raycast(ray,out hit))
                {
                    try
                    {
                        ISubjectInteraction subject = hit.collider.GetComponent<ISubjectInteraction>() ?? throw new NotFoundInteractExeption();
                        if(subject.Type == task.interactionEntity && subject.IsActive)
                        {
                            integrable.Interact_Pressed += subject.Interact;
                            Interact_Prepared?.Invoke(this,null);
                        }else
                        {
                            integrable.ResetEvent();
                            Interact_NotPrepared.Invoke(this,null);
                        }
                    }catch(NotFoundInteractExeption ex)
                    {
                        Interact_NotPrepared.Invoke(this, null);
                    }
                }
                else
                {
                    Interact_NotPrepared.Invoke(this, null);
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}

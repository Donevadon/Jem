using System;
using UnityEngine;

namespace GameLibrary
{
    public interface IInteraction
    {
        IInteractEvent InteractEvent { set; }
        void FindInteractObject(Collider o);
        void RemoveInteractObject(Collider o);
    }
}
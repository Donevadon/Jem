using System;
using UnityEngine;

namespace GameLibrary
{
    public interface IInteraction
    {
        void IdentifyFoundObject (Collider o);
        void RemoveInteractObject(Collider o);
    }
}
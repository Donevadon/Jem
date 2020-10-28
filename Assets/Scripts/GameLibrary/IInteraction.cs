using System;
using UnityEngine;

namespace GameLibrary
{
    public interface IInteraction
    {
        void StartSearchingInteractiveObject(Collider collider);
        void StopSearch(Collider collider);
        void InvokeInteract(object sender);
    }
}
using System;
using System.Collections;


namespace GameLibrary.Interactions
{
    internal interface IPointerToInteractObject
    {
        Task Task { get; set; }
        IEnumerator FindInteractObject();
        event EventHandler Interact_Prepared;
        event EventHandler Interact_NotPrepared;
    }
}
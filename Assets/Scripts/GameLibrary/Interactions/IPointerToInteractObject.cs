using System;
using System.Collections;


namespace GameLibrary.Interactions
{
    internal interface IPointerToInteractObject
    {
        IEnumerator FindInteractObject(Task task);
        event EventHandler Interact_Prepared;
        event EventHandler Interact_NotPrepared;
    }
}
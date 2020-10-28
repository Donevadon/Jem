using System;


namespace GameLibrary.Interactions
{
    internal interface IIntegrable
    {
        void ResetEvent();
        event EventHandler Interact_Pressed;
    }
}
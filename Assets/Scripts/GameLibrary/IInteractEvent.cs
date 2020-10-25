using System;

namespace GameLibrary
{
    public interface IInteractEvent
    {
        event EventHandler InteractPressed;
        bool IsSubscriber { get; }
    }
}
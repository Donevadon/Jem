using System;

namespace GameLibrary.Interactions
{
    public interface ISubjectInteraction
    {
        InteractionEntity Type { get; }
        bool IsActive { get; }
        void Interact(object sender, EventArgs args);
    }

    public interface IActivateSubjectInteraction : ISubjectInteraction
    {
        void Activate();
    }
}
namespace GameLibrary.Interactions
{
    public interface ISubjectInteraction
    {
        InteractionEntity Type { get; }
        void Interact();
    }
}
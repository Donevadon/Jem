namespace GameLibrary.Interactions
{
    struct Task
    {
        public readonly InteractionEntity interactionEntity;
        public readonly string taskMessage;

        public Task(InteractionEntity interactionEntity)
        {
            this.interactionEntity = interactionEntity;
            taskMessage = interactionEntity.ToString();
        }
    }
}
namespace GameLibrary.Interactions
{
    internal struct Task
    {
        public readonly InteractionEntity interactionEntity;
        public readonly string taskMessage;

        public Task(InteractionEntity interaction)
        {
            interactionEntity = interaction;
            taskMessage = null;
            taskMessage = GetMessage(interaction);
        }

        private string GetMessage(InteractionEntity entity)
        {
            switch (entity)
            {
                case InteractionEntity.Rise:
                    return "Встать с кровати";
                case InteractionEntity.MusicPlayer:
                    return "Включить проигрыватель";
                case InteractionEntity.CoffeeMachine:
                    return "Сделать чашку кофе";
                case InteractionEntity.Cup:
                    return "Выпить кофе";
                case InteractionEntity.Window:
                    return "Открыть окно";
                case InteractionEntity.WateringCan:
                    return "Найти лейку";
                case InteractionEntity.FirstFlower:
                    return "Полить один цветочек";
                case InteractionEntity.SecondFlower:
                    return "Полить второй цветочек";
                case InteractionEntity.ThirdFlower:
                    return "Полить третий цветочек";
                case InteractionEntity.GuitarCase:
                    return "Найти розовую крошку";
                case InteractionEntity.RifleInCase:
                    return "Достать розовую крошку";
                case InteractionEntity.Windowsill:
                    return "Установить на подоконник";
                case InteractionEntity.Rifle:
                    return "Вооружиться";
                case InteractionEntity.KillAll:
                    return "УБИТЬ ИХ ВСЕХ!";
                default:
                    throw new System.Exception("Неверный тип");
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary.Interactions
{
    internal class TaskManager : ITasksManager
    {
        private Queue<Task> tasks;

        internal TaskManager()
        {
            CreateTaskList();
        }

        public Task Dequeue()
        {
            return tasks.Dequeue();
        }

        public Task Peek()
        {
            return tasks.Peek();
        }

        private void CreateTaskList()
        {
            tasks = new Queue<Task>();
            tasks.Enqueue(new Task(InteractionEntity.MusicPlayer));
            tasks.Enqueue(new Task(InteractionEntity.CoffeeMachine));
            tasks.Enqueue(new Task(InteractionEntity.Cup));
            tasks.Enqueue(new Task(InteractionEntity.Window));
            tasks.Enqueue(new Task(InteractionEntity.WateringCan));
            tasks.Enqueue(new Task(InteractionEntity.FirstFlower));
            tasks.Enqueue(new Task(InteractionEntity.SecondFlower));
            tasks.Enqueue(new Task(InteractionEntity.ThirdFlower));
            tasks.Enqueue(new Task(InteractionEntity.GuitarCase));
            tasks.Enqueue(new Task(InteractionEntity.RifleInCase));
            tasks.Enqueue(new Task(InteractionEntity.Windowsill));
            tasks.Enqueue(new Task(InteractionEntity.Rifle));
            tasks.Enqueue(new Task(InteractionEntity.KillAll));
        }

    }
}

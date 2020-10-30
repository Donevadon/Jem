using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameLibrary.Interactions.GraphicDisplay
{
    internal class Display : MonoBehaviour, IGraphicDisplay
    {
        private static Display display;

        [SerializeField]private Text taskText;
        [SerializeField] private GameObject interactText;

        private void Awake()
        {
            display = this;
        }

        public static Display GetInstance()
        {
            return display;
        }

        public void CleanUpInteractPrepared()
        {
            interactText.SetActive(false);
        }

        public void ShowInteractPrepared()
        {
            interactText.SetActive(true);
        }

        public void UpdateTask(Task task)
        {
            StartCoroutine(ChangeText(task));
        }

        private IEnumerator ChangeText(Task task)
        {
            string buffer = "";
            foreach (char c in taskText.text)
            {
                buffer = buffer + c + '\u0336';
            }
            taskText.text = buffer;
            yield return new WaitForSeconds(1);
            while(taskText.color.a >= 0)
            {
                taskText.color = new Color(taskText.color.r, taskText.color.g, taskText.color.b, taskText.color.a - 5 * Time.deltaTime);
                yield return new WaitForSeconds(0);
            }

            taskText.text = task.taskMessage;

            while(taskText.color.a <= 1)
            {
                taskText.color = new Color(taskText.color.r, taskText.color.g, taskText.color.b, taskText.color.a + 5 * Time.deltaTime);
                yield return new WaitForSeconds(0);
            }
        }
    }
}

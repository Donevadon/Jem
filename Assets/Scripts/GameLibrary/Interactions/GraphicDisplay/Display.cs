using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace GameLibrary.Interactions.GraphicDisplay
{
    public class Display : MonoBehaviour, IGraphicDisplay
    {
        private static Display display;

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary.Interactions.Testing
{
    public class MockSubjectInteract : MonoBehaviour, ISubjectInteraction
    {
        public InteractionEntity Type { get; }

        public void Interact()
        {
            print("Чё то делаю");
        }
    }
}
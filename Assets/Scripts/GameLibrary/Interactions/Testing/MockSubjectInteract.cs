using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary.Interactions.Testing
{
    public class MockSubjectInteract : MonoBehaviour, ISubjectInteraction
    {
        public InteractionEntity Type => InteractionEntity.MusicPlayer;

        public bool IsActive { get; private set; } = true;

        public void Interact(object sender, EventArgs args)
        {
            if (IsActive)
            {
                print("Чё то делаю");
                IsActive = false;
            }

        }
    }
}
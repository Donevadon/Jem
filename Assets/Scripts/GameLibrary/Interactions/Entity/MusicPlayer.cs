using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary.Interactions.Entity
{
    public class MusicPlayer : MonoBehaviour, ISubjectInteraction
    {
        public InteractionEntity Type => InteractionEntity.MusicPlayer;

        public bool IsActive => throw new NotImplementedException();

        public void Interact(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
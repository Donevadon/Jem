using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLibrary.Interactions.Entity
{
    public class MusicPlayer : MonoBehaviour, ISubjectInteraction
    {
        public InteractionEntity Type => InteractionEntity.MusicPlayer;
        [SerializeField]private AudioSource audioSource;
        [SerializeField] private AudioClip speech;

        public bool IsActive { get; private set; } = true;

        public void Interact(object sender, EventArgs args)
        {
            audioSource.Play();
            IsActive = false;
            MonoBehaviour player = sender as MonoBehaviour;
            AudioSource sourcePlayer = player.GetComponent<AudioSource>();
            sourcePlayer.clip = speech;
            sourcePlayer.Play();
        }
    }
}
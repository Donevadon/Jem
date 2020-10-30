using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLibrary.Interactions.Entity
{
    public class Window : MonoBehaviour, ISubjectInteraction
    {
        public InteractionEntity Type => InteractionEntity.Window;

        [SerializeField]private Animator animator;
        [SerializeField] private AudioClip speech;
        [SerializeField] private AudioClip speech2;



        public bool IsActive { get; private set; } = true;

        public void Interact(object sender, EventArgs args)
        {
            IsActive = false;
            animator.SetBool("OpenWindow", true);
            MonoBehaviour player = sender as MonoBehaviour;
            AudioSource sourcePlayer = player.GetComponent<AudioSource>();
            sourcePlayer.clip = speech;
            sourcePlayer.Play();
            StartCoroutine(MusicTimer());


            IEnumerator MusicTimer()
            {
                while (sourcePlayer.isPlaying)
                {
                    yield return new WaitForSeconds(0.5f);
                }
                sourcePlayer.clip = speech2;
                sourcePlayer.Play();
            }
        }
    }
}

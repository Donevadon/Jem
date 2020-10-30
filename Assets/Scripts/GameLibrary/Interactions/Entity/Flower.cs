using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour, ISubjectInteraction
{
    [SerializeField]private InteractionEntity type;
    public InteractionEntity Type => type;
    public GameObject WateringCan;
    public AudioSource audioSource;
    private Animator animator;

    [SerializeField] private AudioClip speech;


    public bool IsActive { get; private set; } = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        StartCoroutine(Pour());
        MonoBehaviour player = sender as MonoBehaviour;
        AudioSource sourcePlayer = player.GetComponent<AudioSource>();
        sourcePlayer.clip = speech;
        sourcePlayer.Play();
    }

    private IEnumerator Pour()
    {
        WateringCan.SetActive(true);
        animator.SetBool("Pour",true);
        audioSource.Play();
        yield return new WaitForSeconds(3);
        WateringCan.SetActive(false);
        yield break;
    }
}

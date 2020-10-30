using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour, ISubjectInteraction
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField]private GameObject cup;
    private IActivateSubjectInteraction cupActive;

    public InteractionEntity Type => InteractionEntity.CoffeeMachine;

    public bool IsActive { get; private set; } = true;

    private void Awake()
    {
        cupActive = cup.GetComponent<IActivateSubjectInteraction>();
    }

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }
        cupActive.Activate();
    }
}

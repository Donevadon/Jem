using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chehol : MonoBehaviour, ISubjectInteraction
{
    public InteractionEntity Type => InteractionEntity.GuitarCase;
    public GameObject Cap;
    public AudioSource audioSource;

    public bool IsActive { get; private set; } = true;

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        audioSource.Play();
        Cap.SetActive(false);
    }
}

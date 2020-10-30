using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleInCase : MonoBehaviour, ISubjectInteraction
{
    public InteractionEntity Type => InteractionEntity.RifleInCase;
    public AudioSource AudioSource;

    public bool IsActive { get; private set; } = true;

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        AudioSource.Play();
        GetComponent<MeshFilter>().mesh = null;
    }
}

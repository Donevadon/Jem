using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, ISubjectInteraction
{
    public InteractionEntity Type => InteractionEntity.WateringCan;
    public AudioSource audioSource;

    public bool IsActive { get; private set; } = true;

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        audioSource.Play();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        GetComponent<MeshFilter>().mesh = null;
    }
}

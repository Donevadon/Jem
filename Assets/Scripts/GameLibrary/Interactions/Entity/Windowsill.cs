using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windowsill : MonoBehaviour, ISubjectInteraction
{
    public InteractionEntity Type => InteractionEntity.Windowsill;
    public GameObject Rifle;

    public bool IsActive { get; private set; } = true;

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        Rifle.SetActive(true);
    }
}

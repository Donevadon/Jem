using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beginning : MonoBehaviour, ISubjectInteraction
{
    public InteractionEntity Type => InteractionEntity.Rise;

    public bool IsActive { get; private set; } = true;

    public void Interact(object sender, EventArgs args)
    {
        throw new NotImplementedException();
    }
}

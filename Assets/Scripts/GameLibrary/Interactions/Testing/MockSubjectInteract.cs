using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockSubjectInteract : MonoBehaviour, ISubjectInteraction
{
    public void Interact()
    {
        print("Чё то делаю");
    }
}

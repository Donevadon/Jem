using GameLibrary.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour, IActivateSubjectInteraction
{
    private MeshFilter meshFilter;
    [SerializeField]private AudioSource source;

    public InteractionEntity Type => InteractionEntity.Cup;
    public Mesh ActiveMesh;
    public Mesh DeactiveMesh;

    public bool IsActive { get; private set; } = false;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    public void Activate()
    {
        IsActive = true;
        meshFilter.mesh = ActiveMesh;
    }

    public void Interact(object sender, EventArgs args)
    {
        IsActive = false;
        meshFilter.mesh = null;
        StartCoroutine(Drink());
    }

    private IEnumerator Drink()
    {
        source.Play();
        while (source.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }
        meshFilter.mesh = DeactiveMesh;
    }
}

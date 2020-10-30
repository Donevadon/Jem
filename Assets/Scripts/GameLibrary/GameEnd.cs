using GameLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    private int score = 0;
    private AudioSource final;

    private void Awake()
    {
        final = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IZombi>() != null)
        {
            final.Play();
            score++;
            Destroy(other.gameObject);
            if(score > 10)
            {
                Final();
            }
        }
    }

    private void Final()
    {
        SceneManager.LoadScene("Dead");
    }

}

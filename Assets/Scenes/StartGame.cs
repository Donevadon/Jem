using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource audio1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Start_Game());
        }
    }

    IEnumerator Start_Game()
    {
        audio1.Play();
        while (audio1.isPlaying)
        {
            yield return new WaitForSeconds(0);
        }
        SceneManager.LoadScene("Game");
    }
}

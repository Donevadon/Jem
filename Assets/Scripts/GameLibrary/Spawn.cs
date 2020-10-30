using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Zombi;
    private static List<Spawn> spawns = new List<Spawn>();

    public static void StartAllSpawn()
    {
        foreach(var spawn in spawns)
        {
            spawn.StartSpawn();
        }
    }
    private void Awake()
    {
        spawns.Add(this);
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            Instantiate(Zombi, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(8);
        }
    }
}

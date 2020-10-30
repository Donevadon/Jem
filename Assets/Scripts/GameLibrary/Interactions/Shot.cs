using GameLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombi
{
    bool IsDead { get; }
    void Dead();
}

public class Shot : MonoBehaviour, IShoot
{
    private float rechargeTime;
    private float recharge = 1.5f;
    private AudioSource audioShoot;

    private void Awake()
    {
        audioShoot = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if(rechargeTime <= 0)
        {
            Raycast();
        }
    }


    private void Raycast()
    {
        rechargeTime = recharge;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;
        audioShoot.Play();
        RaycastHit[] objs = Physics.RaycastAll(ray.origin, ray.direction * 200);
        foreach(var obj in objs)
        {
            IZombi zombi = obj.collider.GetComponent<IZombi>();
            if (zombi != null && zombi.IsDead == false) zombi.Dead();
        }
    }

    private void Update()
    {
        if (rechargeTime > 0) rechargeTime -= Time.deltaTime; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoShoot : Shooting
{
    public Animator anima;
    public int rpm;
    public AudioSource sound;
    public GunRaycaster gunRaycaster;

    private float lastshot;
    private float interval;
    public UnityEvent onshoot;
    // Start is called before the first frame update
    void Start()
    {
        interval = 60f / rpm;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }

    private void UpdateFiring()
    {
        if(Time.time - lastshot >= interval)
        {
            Shoot();
            lastshot = Time.time;
        }
    }

    private void Shoot()
    {
        anima.Play("AutoShoot", layer: -1, normalizedTime:0) ;
        sound.Play();
        gunRaycaster.PerformRayCasting();
        onshoot.Invoke();
    }
}

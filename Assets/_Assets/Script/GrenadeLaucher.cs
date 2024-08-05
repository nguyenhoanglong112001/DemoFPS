using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLaucher : Shooting
{
    private const int LeftMouseButton = 0;
    public GameObject bulletPrefab;
    public Transform firingPos;
    public float bulletspeed;
    public AudioSource bulletSound;
    public Animator gunanimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        } 
            
    }

    public void ShootBullet()
    {
        gunanimator.SetTrigger("Shoot");
        Debug.Log("Shoot");
    }

    public void PlayFireSound()
    {
        bulletSound.Play();
        Debug.Log("Sound");
    }

    public void AddProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firingPos.forward * bulletspeed;
        Debug.Log("Fire");
    }
}

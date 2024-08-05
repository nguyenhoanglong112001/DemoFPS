using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int magazine;
    [SerializeField] private Shooting shooting;
    [SerializeField] private Animator anima;
    [SerializeField] private AudioSource reloadsound;
    public UnityEvent loadAmmoChanged;

    private int _loadedAmmo;

    public int LoadedAmmo 
    { 
        get => _loadedAmmo;
        set 
        {
            _loadedAmmo = value;
            loadAmmoChanged.Invoke();
            if(_loadedAmmo<=0)
            {
                Reload();
                LockShoting();
            }
            else
            {
                UnLockShoting();
            }
        }
    }

    public int Magazine { get => magazine; set => magazine = value; }

    // Start is called before the first frame update
    void Start()
    {
        RefillAmmo();   
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    private void Reload()
    {
        anima.SetTrigger("Reload");
        LockShoting();
    }

    public void AddAmmo() => RefillAmmo();
    public void SingleFireAmmoCouter() => LoadedAmmo--;
    private void LockShoting() => shooting.enabled = false;

    private void UnLockShoting() => shooting.enabled = true;

    private void RefillAmmo() => LoadedAmmo = magazine;

    public void PlayReloadSound() => reloadsound.Play();

    public void OnGunSelected() => UpdateShootingLock();

    private void UpdateShootingLock()
    {
        shooting.enabled = _loadedAmmo > 0;
    }
}

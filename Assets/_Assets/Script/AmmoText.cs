using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    [SerializeField] private Text loadAmmoText;
    public Ammo ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo.loadAmmoChanged.AddListener(UpdateGunAmmo);
        UpdateGunAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if(ammo != null)
        {
            ammo.loadAmmoChanged.AddListener(UpdateGunAmmo);
            UpdateGunAmmo();
        }
    }

    public void UpdateGunAmmo()
    {
        Debug.Log(ammo.Magazine);   
        loadAmmoText.text = ammo.LoadedAmmo.ToString() + "/" + ammo.Magazine.ToString();
    }
}

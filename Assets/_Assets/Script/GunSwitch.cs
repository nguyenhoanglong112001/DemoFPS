using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject[] guns;
    public AmmoText settext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<guns.Length;i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1+i) || Input.GetKeyDown(KeyCode.Keypad1+i))
            {
                SetActiveGun(i);
            }
        }
    }

    private void SetActiveGun(int gunindex)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            bool isActive = (i == gunindex);
            guns[i].SetActive(isActive);
            settext.ammo = guns[i].GetComponent<Ammo>();
            if(isActive)
            {
                guns[i].SendMessage("OnGunSelect", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}

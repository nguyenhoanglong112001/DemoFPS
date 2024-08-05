using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public GameObject hitmakerPrefab;
    public Camera aimingcamera;
    public LayerMask layer;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingcamera.transform.position, aimingcamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitinfo, 1000f, layer))
        {
            ShowHitEffect(hitinfo);
            DeliverDame(hitinfo);
        }
    }

    private void DeliverDame(RaycastHit hitinfo)
    {
        Health health = hitinfo.collider.GetComponentInParent<Health>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }
    }

    private void ShowHitEffect(RaycastHit hitinfo)
    {
        HitSurface hitSurface = hitinfo.collider.GetComponent<HitSurface>();
        if(hitSurface!= null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if(effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitinfo.normal);
                Instantiate(effectPrefab, hitinfo.point, effectRotation);
            }
        }
    }
}

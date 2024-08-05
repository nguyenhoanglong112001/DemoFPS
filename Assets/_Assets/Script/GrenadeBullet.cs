using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionPrefab;
    public int damage;
    public float explosionRadius;
    public float explosionForce;

    private List<Health> oldVictims = new List<Health>();

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }

    private void BlowObject()
    {
        oldVictims.Clear();
        Collider[] affectOnbjects = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i=0;i<affectOnbjects.Length;i++)
        {
            Rigidbody rigid = affectOnbjects[i].attachedRigidbody;
            if(rigid)
            {
                DeliverDame(affectOnbjects[i]);
                AddForceToObject(affectOnbjects[i]);
            }
        }
    }

    private void DeliverDame(Collider victim)
    {
        Health health = victim.GetComponentInParent<Health>();
        if (health != null && oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }

    private void AddForceToObject(Collider affectObject)
    {
        Rigidbody rigibody = affectObject.attachedRigidbody;
        if(rigibody)
        {
            rigibody.AddExplosionForce(explosionForce, transform.position, explosionForce, 1, ForceMode.Impulse);
        }
    }
}

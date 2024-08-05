using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    public int lifetime;
    [SerializeField] private AudioSource soundexplosion;
    private void Start()
    {
        soundexplosion.Play();
        Destroy(gameObject, lifetime);
    }
}

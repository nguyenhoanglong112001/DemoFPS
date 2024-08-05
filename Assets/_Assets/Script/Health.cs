using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public UnityEvent onDie;
    public UnityEvent<int,int> onHealthChange;
    public UnityEvent OnTakeDamage;

    private int _healthPointValue;
    private bool IsDead => HealthPoint <= 0;

    public int HealthPoint 
    { 
        get => _healthPointValue; set 
        {
            _healthPointValue = value;
            onHealthChange.Invoke(_healthPointValue, maxHealthPoint);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthPoint = maxHealthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int Dame)
    {
        if (IsDead) return;

        HealthPoint -= Dame;
        OnTakeDamage?.Invoke();
        if(IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        onDie.Invoke();
    }
}

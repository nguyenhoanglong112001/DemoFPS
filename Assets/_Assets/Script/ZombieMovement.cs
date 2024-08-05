using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerfoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRadius;
    public UnityEvent OnDestionationReach;
    public UnityEvent OnStartMoving;

    private bool _isMovingValue;
    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if(_isMovingValue == value)
            {
                return;
            }
            _isMovingValue = value;
            OnIsMovingValueChange();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerfoot.position);
        IsMoving = distance > reachingRadius;
        if (IsMoving)
        {
            agent.SetDestination(playerfoot.position);;
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("IsWalking", false);
        }
    }

    private void OnIsMovingValueChange()
    {
        agent.isStopped = !_isMovingValue;
        anim.SetBool("IsWalking", _isMovingValue);
        if(_isMovingValue)
        {
            OnStartMoving.Invoke();
        }
        else
        {
            OnDestionationReach.Invoke();   
        }
    }


    public void OnDie()
    {
        enabled = false;
        agent.isStopped = true;
    }
}

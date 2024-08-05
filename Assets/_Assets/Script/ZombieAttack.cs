using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public Health playerHealth;

    public void StartAttack() => anim.SetBool("IsAttack",true);

    public void StopAttack() => anim.SetBool("IsAttack", false);

    public void OnAttack(int index)
    {
        playerHealth.TakeDamage(damage);
        if(index == 1)
        {
            Player.Instance.playerUI.ShowLeftScratch();
        }
        else
        {
            Player.Instance.playerUI.ShowRightScratch();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void AnimTrigger(string triggerName)
    {
        ResetTriggers();
        animator.SetTrigger(triggerName);
    }

    void ResetTriggers()
    {
        animator.ResetTrigger("Die");
        animator.ResetTrigger("GetHit");
        animator.ResetTrigger("Attack");
    }
}

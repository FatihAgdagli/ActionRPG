using System;
using UnityEngine;

public class UnitAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private enum AnimationState
    {
        Idle_01 = 0,
        Idle_02,
        Victory_01,
        Victory_02,
        Death_01,
        Death_02,
        Death_03,
        Run,
        WorkingOnDevice,
    }

    private enum AnimationTrigger
    {
        Damage = 0,
        EffectDamage,
        Attack_01,
        Attack_02,
    }

    public void PlayIdle()
    {
        SetAnimtaionState((AnimationState)UnityEngine.Random.Range(0, 2));
    }

    public void PlayAttack()
    {
        string triggerName = ((AnimationTrigger)UnityEngine.Random.Range(2, 4)).ToString();
        animator.SetTrigger(triggerName);
    }

    public void PlayTakeDamage()
    {
        string triggerName = (AnimationTrigger.Damage).ToString();
        animator.SetTrigger(triggerName);
    }

    public void PlayEffectDamage() 
    {
        string triggerName = (AnimationTrigger.EffectDamage).ToString();
        animator.SetTrigger(triggerName);
    }

    public void PlayWorkingOnDevice()
    {
        SetAnimtaionState(AnimationState.WorkingOnDevice);
    }

    public void PlayVictory()
    {
        SetAnimtaionState((AnimationState)UnityEngine.Random.Range(2, 4));
    }

    public void PlayDeath()
    {
        SetAnimtaionState((AnimationState)UnityEngine.Random.Range(4, 7));
    }
    public void PlayRun()
    {
        SetAnimtaionState(AnimationState.Run);
    }

    private void SetAnimtaionState(AnimationState state)
    {
        foreach (string animName in Enum.GetNames(typeof(AnimationState)))
        {
            bool animValue = state.ToString() == animName ? true : false;
            animator.SetBool(animName, animValue);
        }
    }
}

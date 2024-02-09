using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppAttack : State
{
    PenaltyOppBasic _penaltyOppBasic;
    public OppAttack(PenaltyOppBasic penaltyOppBasic)
    {
        _penaltyOppBasic = penaltyOppBasic;
    }

    public override void Enter()
    {
        Debug.Log("Code for Idle while Entering");
        _penaltyOppBasic.animator.SetInteger("EnemyBeh", 1);
        _penaltyOppBasic.animator.Play("Attack");
        
    }

    public override void Exit()
    {
        Debug.Log("Code for Idle while Exiting");
    }

    public override void Update()
    {
        Debug.Log("Code for Idle while Updating");
    }
}

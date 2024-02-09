using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppIdle : State
{
    PenaltyOppBasic _penaltyOppBasic;
    public OppIdle(PenaltyOppBasic penaltyOppBasic)
    {
        _penaltyOppBasic = penaltyOppBasic;
    }

    public override void Enter()
    {
        Debug.Log("Code for Idle while Entering");
        _penaltyOppBasic.animator.SetInteger("EnemyBeh", 0);
        _penaltyOppBasic.animator.Play("Idle");
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

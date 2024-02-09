using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKIdle : State
{
    Goalkeeper _goalKeeper;
    public GKIdle(Goalkeeper GoalKeeper)
    {
        _goalKeeper = GoalKeeper;
    }

    public override void Enter()
    {
        Debug.Log("Code for Idle while Entering");
        _goalKeeper.animator.SetInteger("GkAnimState", 0);
    }

    public override void Exit()
    {
        Debug.Log("Code for Idle while Exiting");
    }

    public override void Update()
    {
        Debug.Log("Code for Idle while Updating");
        _goalKeeper.transform.LookAt(_goalKeeper.Player.transform.position);
    }
}

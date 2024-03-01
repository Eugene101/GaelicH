using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttackOppo : State
{
    BallBasic _ballBasic;
    public BallAttackOppo(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        Debug.Log("I attack ball");
        _ballBasic.status = BallBasic.BallPlayerStatus.isAttackOppo;
    }

    public override void Exit()
    {
    
    }

    public override void Update()
    {
        _ballBasic.transform.LookAt(_ballBasic.wall.transform.position);          
        _ballBasic.transform.position += -Vector3.forward*Time.deltaTime*10f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitting : State
{
    BallBasic _ballBasic;
    public BallHitting(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        
        BallBasic.isHitting = true;
        _ballBasic.rb.velocity = Vector3.Reflect(_ballBasic.rb.velocity, -Vector3.up);
        //_ballBasic.rb.velocity = Vector3.zero;
    }

    public override void Exit()
    {
        BallBasic.isHitting = false;
    }

    public override void Update()
    {

    }
}

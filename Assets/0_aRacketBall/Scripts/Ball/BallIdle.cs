using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIdle : State
{
    BallBasic _ballBasic;
    public BallIdle(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        _ballBasic.transform.position = _ballBasic.ballServeposition.position;
        _ballBasic.rb.detectCollisions = false;
        _ballBasic.rb.isKinematic = true;
        _ballBasic.rb.useGravity = false;
        BallBasic.isIdle = true;
        //_ballBasic.rb.velocity = Vector3.zero;
    }

    public override void Exit()
    {
        _ballBasic.rb.detectCollisions = true;
        _ballBasic.rb.isKinematic = false;
        _ballBasic.rb.useGravity = false;
        BallBasic.isIdle = false;
    }

    public override void Update()
    {

    }
}

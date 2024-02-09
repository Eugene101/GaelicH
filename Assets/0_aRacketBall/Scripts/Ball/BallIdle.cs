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
        _ballBasic.transform.position = Vector3.one * 1000;
        _ballBasic.rb.detectCollisions = false;
        _ballBasic.rb.isKinematic = true;
        _ballBasic.rb.useGravity = false;
        //_ballBasic.rb.velocity = Vector3.zero;
    }

    public override void Exit()
    {
        _ballBasic.rb.detectCollisions = true;
        _ballBasic.rb.isKinematic = false;
        _ballBasic.rb.useGravity = true;
    }

    public override void Update()
    {

    }
}

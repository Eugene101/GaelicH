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
        //_ballBasic.runAfterHitUp = false; _ballBasic.runAfterHitDown = false;
        _ballBasic.transform.position = _ballBasic.ballServeposition.position;
        _ballBasic.rb.detectCollisions = false;
        _ballBasic.rb.isKinematic = true;
        _ballBasic.rb.useGravity = false;
        _ballBasic.status = BallBasic.BallPlayerStatus.isIdle;
        //_ballBasic.rb.velocity = Vector3.zero;
        //_ballBasic.WallLeftTouch = false;
        //_ballBasic.WallRightTouch = false;
     }

    public override void Exit()
    {
        _ballBasic.rb.detectCollisions = true;
        _ballBasic.rb.isKinematic = false;
        _ballBasic.rb.useGravity = false;
    }

    public override void Update()
    {

    }
}

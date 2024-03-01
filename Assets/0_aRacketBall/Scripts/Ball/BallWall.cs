using UnityEngine;


public class BallWall : State
{
    BallBasic _ballBasic;
    Vector3 touchpoint;
    public BallWall(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        _ballBasic.status = BallBasic.BallPlayerStatus.isWall;
        Vector3 dir = _ballBasic.rb.velocity;
        dir.x = 0;
        _ballBasic.rb.velocity = dir;
        //if (RoundManager.isPlayerTurn)
        //{
        //    dir *= 5f;
        //}
    }

    public override void Exit()
    {

        //_ballBasic.WallLeftTouch = false;
        //_ballBasic.WallRightTouch = false;
    }

    public override void Update()
    {

    }
}

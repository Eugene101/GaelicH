using Oculus.Interaction;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

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
        BallBasic.isWall = true;

        //if (_ballBasic.WallLeftTouch)
        //{
        //    Debug.Log("Left wall touch");
        //    if (_ballBasic.wTouch > 2)
        //    {
        //        _ballBasic.rb.AddForce(-10f, 0f, 0f);
        //    }
        //}

        //else if (_ballBasic.WallRightTouch)
        //{
        //    Debug.Log("Right wall touch");
        //    if (_ballBasic.wTouch > 2)
        //    {
        //        _ballBasic.rb.AddForce(2f, 0f, 0f);
        //    }
        //}
        Vector3 dir = _ballBasic.rb.velocity;
        dir.x = 0;
        _ballBasic.rb.velocity = dir;
    }

    public override void Exit()
    {
        BallBasic.isWall = false;
        _ballBasic.WallLeftTouch = false;
        _ballBasic.WallRightTouch = false;
    }

    public override void Update()
    {

    }
}

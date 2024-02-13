using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BallServe : State
{
    BallBasic _ballBasic;




    public BallServe(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }



    public override void Enter()
    {
        BallBasic.isServing = true;
        _ballBasic.rb.isKinematic = false;
        BallBasic.ballDirectionDown = true;
        _ballBasic.initialPosition = _ballBasic.transform.position;
    }

    public override void Exit()
    {
        BallBasic.isServing = false;

    }

    public override void Update()
    {
        //if (BallBasic.ballDirectionDown)
        //{
        //    _ballBasic.transform.position = Vector3.Lerp(_ballBasic.transform.position, _ballBasic.transform.position)
        //}
        float newY = _ballBasic.initialPosition.y + Mathf.Sin(Time.time * _ballBasic.bounceSpeed) * _ballBasic.amplitude;

        // Update the position of the ball
        _ballBasic.transform.position = new Vector3(_ballBasic.transform.position.x, newY, _ballBasic.transform.position.z);

    }
}

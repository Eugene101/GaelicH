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
    }

    public override void Exit()
    {
        BallBasic.isServing = false;
    }

    public override void Update()
    {
        float ballDist = Vector3.Distance(_ballBasic.transform.position, _ballBasic.ballServeposition+ new Vector3(0,0.25f,0));

        if (BallBasic.ballDirectionUp)
        {
            //_ballBasic.rb.isKinematic = true;
            if (ballDist > 0.2f || _ballBasic.transform.position.y>1f)
            {
                _ballBasic.rb.velocity = new Vector3(0f, _ballBasic.ballServeSpeed * 10, 0f) ;
                //_ballBasic.transform.position = Vector3.Lerp(_ballBasic.transform.position, _ballBasic.ballServeposition, _ballServeSpeed);
            }

            else
            {
                //_ballBasic.rb.useGravity = true;
                BallBasic.ballDirectionUp = false;
                BallBasic.ballDirectionDown = true;
                //_ballBasic.ballServeposition = _ballBasic.transform.position;
            }

        }

        if (BallBasic.ballDirectionDown)
        {
            //_ballBasic.transform.position = Vector3.Lerp(_ballBasic.transform.position, _ballBasic.ballGroundposition, _ballServeSpeed);
            _ballBasic.rb.velocity = new Vector3(0f, -_ballBasic.ballServeSpeed *10, 0f);
        }

       



        //if (BallBasic.returnBall)
        //{
        //    if (ballDist >= 0.02)
        //    {
        //        _ballBasic.transform.position = Vector3.Slerp(_ballBasic.transform.position, _ballBasic.ballServeposition + new Vector3(0f, 0.5f, 0f), _ballServeSpeed);
        //    }

        //    else { BallBasic.returnBall = false; }
        //}
        //_ballBasic.lastVelocity =


    }
}

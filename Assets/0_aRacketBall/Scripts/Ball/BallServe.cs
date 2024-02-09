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
    }

    public override void Exit()
    {
        BallBasic.isServing = false;

    }

    public override void Update()
    {
        float ballDist = Vector3.Distance(_ballBasic.transform.position, _ballBasic.ballServeposition + new Vector3(0, 0.25f, 0));

        if (BallBasic.ballDirectionUp)
        {
            //_ballBasic.rb.isKinematic = true;
            if (ballDist > 0.2f || _ballBasic.transform.position.y > 1f)
            {
                _ballBasic.rb.velocity = new Vector3(0f, _ballBasic.ballServeSpeed * 10, 0f);
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
            if (_ballBasic.rb.isKinematic)
            {
                _ballBasic.rb.isKinematic = false;
            }
            
            _ballBasic.rb.velocity = new Vector3(0f, -_ballBasic.ballServeSpeed * 10, 0f);
        }
        if (_ballBasic.transform.position.y > _ballBasic.ballServeposition.y)
        {
            _ballBasic.rb.velocity = Vector3.zero;
            _ballBasic.rb.angularVelocity = Vector3.zero;
            BallBasic.ballDirectionUp = false;
            BallBasic.ballDirectionDown = true;
            _ballBasic.rb.velocity += new Vector3(0f, -1f, 0f);
        }

    }
}

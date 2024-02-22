using Oculus.Interaction;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class BallHitting : State
{
    BallBasic _ballBasic;
    Vector3 delta;
    Vector3 newPos;
    public BallHitting(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        BallBasic.isHitting = true;

        
        Vector3 dir = (_ballBasic.hitAssistDot.transform.position - _ballBasic.transform.position);
        dir.x = _ballBasic.rb.velocity.x;

        _ballBasic.rb.velocity = dir.normalized + new Vector3(0, _ballBasic.floorBounceyUpForce, 0);



    }

    public override void Exit()
    {
        BallBasic.isHitting = false;
    }

    public override void Update()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaa" + _ballBasic.rb.velocity.magnitude);

        float delta = _ballBasic.transform.position.x - _ballBasic.hand.transform.position.x;
        _ballBasic.rb.AddForce(delta*Time.deltaTime, 0f, _ballBasic.maxvelocity * Time.deltaTime);
        _ballBasic.rb.velocity = new Vector3(_ballBasic.rb.velocity.x, _ballBasic.rb.velocity.y, _ballBasic.toPlayer);

        //if (_ballBasic.rb.velocity.magnitude > _ballBasic.maxvelocity)
        //{
        //    _ballBasic.rb.velocity*=0.8f;
        //}

        //if (_ballBasic.rb.velocity.magnitude < _ballBasic.minvelocity)
        //{
        //    _ballBasic.rb.velocity *= 1.1f;
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting.FullSerializer;
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
        _ballBasic.rb.AddForce((_ballBasic.direction + _ballBasic.refelct) * 0.009f, ForceMode.Impulse);
    }

    public override void Exit()
    {
        BallBasic.isHitting = false;
    }
    
    public override void Update()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaa");
        var dist = Vector3.Distance(_ballBasic.transform.position, _ballBasic.hand.transform.position);
        //if (BallBasic.isHitting)
        //{
        //    _ballBasic.rb.velocity = Vector3.zero;
        //    _ballBasic.rb.angularVelocity = Vector3.zero;
        //    _ballBasic.transform.position = Vector3.Slerp(_ballBasic.transform.position, _ballBasic.hand.transform.position, 0.05f);
        //    var dist = Vector3.Distance(_ballBasic.transform.position, _ballBasic.hand.transform.position);
        //    if (dist <= 0.2f)
        //    {
        //        BallBasic.isHitting = false;
        //        _ballBasic.Idle();
        //    }
        //}
        //_ballBasic.rb.velocity *= _ballBasic.velocityCoeff;

        //Vector3 direction = _ballBasic.hand.transform.position - _ballBasic.transform.position;

        ////direction.z = 0f;
        //direction.x = Mathf.Clamp(direction.x, -5, 5);
        //_ballBasic.rb.AddForce(direction * 0.01f);
        // _ballBasic.rb.velocity = _ballBasic.rb.velocity * Time.deltaTime * 5;
        //Vector3 clamp = _ballBasic.rb.velocity;
        //clamp.y = Mathf.Clamp(clamp.y, clamp.y, 4);
        //_ballBasic.rb.velocity = clamp;
        //if (_ballBasic.rb.velocity.magnitude > 5f && dist<5f)
        //{
        //    _ballBasic.rb.velocity = Vector3.zero;
        //}

    }
}

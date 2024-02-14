using System.Collections;
using System.Collections.Generic;
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
    }

    public override void Exit()
    {
        BallBasic.isHitting = false;
    }

    public override void Update()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaa");
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
        Vector3 direction = _ballBasic.hand.transform.position - _ballBasic.transform.position;
        //direction.z = 0f;
        _ballBasic.rb.AddForce(direction * 0.2f);
    }
}

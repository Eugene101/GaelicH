using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BallAttackOppo : State
{
    BallBasic _ballBasic;
    public BallAttackOppo(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        Debug.Log("I attack ball");
        _ballBasic.status = BallBasic.BallPlayerStatus.isAttackOppo;
    }

    public override void Exit()
    {
    
    }

    public override void Update()
    {
        _ballBasic.transform.LookAt(_ballBasic.wall.transform.position);
        //_ballBasic.transform.position += (-Vector3.forward + 0.2f*Vector3.up) * Time.deltaTime * 12f;
        _ballBasic.rb.AddForce(-Vector3.forward * 50f*Time.deltaTime + 0.8f*Vector3.up/*, ForceMode.Impulse*/);
        Debug.Log("Speed: " + _ballBasic.rb.velocity.magnitude);

        //if (_ballBasic.rb.velocity.magnitude < 5f)
        //{
        //    _ballBasic.rb.velocity *= 1.2f;
        //}

        //else
        //{
        //    _ballBasic.rb.velocity *= 0.8f;
        //}

        //Vector3 dir = _ballBasic.wall.transform.position - _ballBasic.transform.position;
        //dir.y = _ballBasic.rb.velocity.y;
        //dir.z = _ballBasic.rb.velocity.z;
        //_ballBasic.rb.velocity = dir.normalized;

        //_ballBasic.transform.position = dir;
    }
}

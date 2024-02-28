using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class BallAttack : State
{
    BallBasic _ballBasic;
    float xshift;
    float yshift;
    public BallAttack(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        Vector3 dir = _ballBasic.wall.transform.position - _ballBasic.transform.position;

        //Vector3 directionToObject = _ballBasic.transform.position - _ballBasic.hand.transform.position;
        //float angle = Vector3.Angle(_ballBasic.hand.transform.forward, directionToObject);
        //Debug.Log("angle " + angle);


        if (_ballBasic.goLeft)
        {
            xshift = Random.Range(1f, 2f);
        }
        else if (_ballBasic.goRight)
        {
            xshift = Random.Range(-1f, -2f);
        }

        float power = _ballBasic.RightControllerVelocity.magnitude;
        Debug.Log("power: " + power);

        if (power > 2f)
        {
            yshift = -1f;

            if (xshift < 0)
            {
                xshift += (-1);
            }

            else
            {
                xshift += 1;
            }
        }

        else if (power < 1.5f)
        {
            yshift = -2f;
        }

        _ballBasic.rb.velocity = dir.normalized * _ballBasic.ballAttackSpeed * power + new Vector3(xshift, _ballBasic.attackUpForce + yshift, 0);
        Debug.Log("xshift:" + xshift + " " + _ballBasic.rb.velocity + " " + power);
        //_ballBasic.rb.AddForce(_ballBasic.hand.transform.up * _ballBasic.ballAttackSpeed * UxrAvatar.LocalAvatar.GetGrabber(UxrHandSide.Right).Velocity.magnitude);
        BallBasic.isAttacking = true;
        _ballBasic.rb.useGravity = true;
        _ballBasic.runAfterHitUp = false; _ballBasic.runAfterHitDown = false;
        _ballBasic.addZ = false;
        _ballBasic.rmZ = false;
        _ballBasic.goLeft = false;
        _ballBasic.goRight = false;
    }

    public override void Exit()
    {
        BallBasic.isAttacking = false;
    }

    public override void Update()
    {

        if (_ballBasic.rb.velocity.magnitude > _ballBasic.serveVelocity)
        {
            _ballBasic.rb.velocity *= 0.8f;
        }

        //Vector3 toCentre = _ballBasic.wall.transform.position - _ballBasic.transform.position;
        //toCentre.z = 0;
        //_ballBasic.rb.AddForce(toCentre*Time.deltaTime*1000f);
    }
}

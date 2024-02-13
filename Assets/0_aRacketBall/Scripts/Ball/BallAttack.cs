using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BallAttack : State
{
    BallBasic _ballBasic;
    public BallAttack(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        _ballBasic.rb.AddForce(_ballBasic.hand.transform.up* _ballBasic.ballAttackSpeed * UxrAvatar.LocalAvatar.GetGrabber(UxrHandSide.Right).Velocity.magnitude);
        BallBasic.isAttacking = true;
    }

    public override void Exit()
    {
        BallBasic.isAttacking = false;
    }

    public override void Update()
    {
        
    }
}

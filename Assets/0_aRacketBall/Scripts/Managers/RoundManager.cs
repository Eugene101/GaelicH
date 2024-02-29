using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    GameObject opponent;
    BallBasic ballBasic;
    OppBase oppBase;
    public static bool isPlayerTurn = true;
    public enum WhoTouchLast
    {
        player, opponent
    }
    
    public WhoTouchLast whoTouchLast;


    
    void Start()
    {
        ballBasic = ball.GetComponent<BallBasic>();
        oppBase = GameObject.Find("Opponent").GetComponent<OppBase>();
    }

    public void PlayerServing()
    {

    }

    public void PlayerAttacking()
    {
        oppBase.FollowBall1();
    }

    public void PlayerIdle()
    {

    }

    public void PlayerHit()
    {

    }

    public void PlayerWall()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    var ballStatus = ballBasic.status;

    //    if (ballStatus == BallBasic.BallPlayerStatus.isIdle)
    //    {
    //        print("Ball is idle");
    //    }

    //    if (ballStatus == BallBasic.BallPlayerStatus.isServing)
    //    {
    //        print("Player serving");
    //    }

    //    if (ballStatus == BallBasic.BallPlayerStatus.isAttacking)
    //    {
    //        print("Player attackng");
    //    }

    //    if (ballStatus == BallBasic.BallPlayerStatus.isHitting)
    //    {
    //        print("Player hitting");
    //    }
    //    if (ballStatus == BallBasic.BallPlayerStatus.isWall)
    //    {
    //        print("Player serving");
    //    }

    //}


}

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
    string managerSignal;
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

    public void SignalFromBall(string ballSignal)
    {
        switch (ballSignal)
        {
            case "PlayerAttacking":
                managerSignal = "followBall";
                break;
            case "PlayerWall":
                managerSignal = "perception";
                break;
            case "PlayerHit":
                managerSignal = "attack";
                break;
            case "GoBack":
                managerSignal = "return";
                break;
            
        }
        //oppBase.ChangeState(managerSignal);
    }
}

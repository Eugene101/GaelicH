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
    void Start()
    {
        ballBasic = ball.GetComponent<BallBasic>();
        oppBase = GameObject.Find("Opponent").GetComponent<OppBase>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (ManipulationsDetectorBall.ballReleased)
        //{
        //    ballBasic.Serve();
        //    ManipulationsDetectorBall.ballReleased = false;
        //}
    }

    void FixedUpdate()
    {


    }
}

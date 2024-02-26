using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public static bool isPlayerTurn = true;

    BallBasic ballBasic;

    void Start()
    {
        ballBasic = ball.GetComponent<BallBasic>();
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

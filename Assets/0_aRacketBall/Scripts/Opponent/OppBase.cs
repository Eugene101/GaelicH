using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppBase : MonoBehaviour
{

    protected StateMachine stateMachine;
    public float speed;
    protected float accuracy;
    protected float perception;
    //protected enum superForce { cube, triangle};
    public Transform oppStartPoint;
    public BallBasic ballBasic;

    public static bool oppIsServing;
    public static bool oppIsAttacking;
    public static bool oppIsIdle;
    public static bool oppIsHitting;
    public static bool oppIsWall;
    public static bool oppIsFollowing1;

    public GameObject wall;
    public GameObject testSphere;

    private void Start()
    {
        //ballBasic = GameObject.Find("Ball").GetComponent<BallBasic>();
        transform.position = oppStartPoint.position;
        stateMachine = new StateMachine();
        stateMachine.Intialize(new OpposIdle(this));
        Events.Attack += FollowBall1;
    }

    public void FollowBall1()
    {
        stateMachine.Intialize(new OppFollow1(this));
    }

    public void GoIdle()
    {
        stateMachine.Intialize(new OpposIdle(this));
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
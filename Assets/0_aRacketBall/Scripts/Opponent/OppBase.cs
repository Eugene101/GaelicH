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
    public GameObject wall;
    public GameObject testSphere;
    public Transform centreOfGround;

    public enum OppStatus
    {
        oppIsServing, oppIsAttacking, oppIsIdle, oppIsHitting, oppIsWall, oppIsFollowing1
    }

    public OppStatus oppStatus;

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

    public void Attack()
    {
        stateMachine.Intialize(new OpposAttack(this));
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
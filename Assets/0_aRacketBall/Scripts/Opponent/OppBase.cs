using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

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
    public Quaternion BasicRot;

    public enum OppStatus
    {
        oppIsServing, oppIsAttacking, oppIsIdle, oppIsHitting, oppIsWall, oppIsFollowing1, oppIsPercepting,oppIsGoBack
    }

    public OppStatus oppStatus;

    private void Start()
    {
        //ballBasic = GameObject.Find("Ball").GetComponent<BallBasic>();
        transform.position = oppStartPoint.position;
        BasicRot = transform.rotation;
        stateMachine = new StateMachine();
        stateMachine.Intialize(new OpposIdle(this));
    }

    public void ChangeState(string managersignal)
    {
        switch (managersignal)
        {
            case "followBall":
                stateMachine.Intialize(new OppFollow1(this));
                break;
            case "perception":
                stateMachine.Intialize(new OppPerception(this));
                break;
            case "attack":
                stateMachine.Intialize(new OpposAttack(this));
                break;
            case "return":
                stateMachine.Intialize(new OpposAfterShoot(this));
                break;
        }
    }
    private void Update()
    {
        stateMachine.currentState.Update();
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            stateMachine.ChangeState(new OpposIdle(this));
            transform.position = oppStartPoint.position;
            transform.rotation = BasicRot;

            //IsTouchWall = false;
        }

        //if (transform.position.z < centreOfGround.transform.position.z)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, centreOfGround.transform.position.z);
        //}

        if (transform.position.z > oppStartPoint.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, oppStartPoint.transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, oppStartPoint.position.y, transform.position.z);
    }
}
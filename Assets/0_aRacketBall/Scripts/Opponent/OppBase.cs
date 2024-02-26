using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppBase : MonoBehaviour
{

    protected StateMachine stateMachine;
    protected float speed;
    protected float accuracy;
    protected float perception;
    //protected enum superForce { cube, triangle};
    public Transform oppStartPoint;
    public BallBasic ballBasic;
    public Action<BallBasic> Ball;

    private void Start()
    {
        ballBasic = GameObject.Find("Ball").GetComponent<BallBasic>();
        stateMachine = new StateMachine();
        stateMachine.Intialize(new OpposIdle(this));
       
    }

}

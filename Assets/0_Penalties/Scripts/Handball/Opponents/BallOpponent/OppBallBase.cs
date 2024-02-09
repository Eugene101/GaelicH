using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppBallBase : MonoBehaviour
{
    StateMachine stateMachine;
    public GameObject oppHand;
    public Transform[] enemyBallTargets;
    public Vector3 ballTarget;
    public float enemyBallSpeed1;
    public Rigidbody rb;
    void Start()
    {
        stateMachine = new StateMachine();
        rb = GetComponent<Rigidbody>();
        stateMachine.Intialize(new OppBallIdle(this));
        
    }

    // Update is called once per frame
    void Update()
    {
        //stateMachine.ChangeState(new  OppWalking(this, OppWalking.direction.forward ));
    }
}

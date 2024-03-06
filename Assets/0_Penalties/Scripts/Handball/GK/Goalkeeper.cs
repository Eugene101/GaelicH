using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goalkeeper : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private enum State { idle, sideJumping, upJumping }
    State state;
    [SerializeField] private Animator anim;

    public GameObject Player
    {
        get { return player; }
    }
    public Animator animator
    {
        get
        {
            return anim;
        }
        private set { anim = value; }
    }
    private StateMachine stateMachine;

    void Start()
    {
        anim = GetComponent<Animator>();
        stateMachine = new StateMachine();
        stateMachine.Intialize(new GKIdle(this));
        Idle();
    }


    void GoalkeeperState()
    {
        switch (state)
        {
            case State.idle: //0
                Idle();
                break;

            case State.sideJumping: //1
                stateMachine.ChangeState(new GKJump(this));
                Invoke("Idle", 1.7f);
                break;
        }
    }

    public void Idle()
    {
        state = State.idle;
        // anim.SetInteger("GkAnimState", 0);
        stateMachine.ChangeState(new GKIdle(this));
    }

    private void Update()
    {
        stateMachine.currentState.Update();
        //if(ManipulationsDetectorBall.ballReleased)
        //{

        //    ManipulationsDetectorBall.ballReleased = false;

        //}
        if ((state == State.idle) && ManipulationsDetectorBall.ballReleased)
        {
            state = State.sideJumping;
            GoalkeeperState();
            ManipulationsDetectorBall.ballReleased = false;
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class BallBasic : MonoBehaviour
{
    StateMachine stateMachine;
    public float ballSpeed;
    Vector3 lastVelocity;
    public float speedFactor;
    public Rigidbody rb;
    public static bool isServing;
    public static bool returnBall;
    public static bool ballDirectionUp;
    public static bool ballDirectionDown;
    public Vector3 ballServeposition;
    public Vector3 ballGroundposition;
    [SerializeField] Transform ballPoint;
    public float ballServeSpeed = 0.1f;
    public static bool iCanSpawnBall = true;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        rb = GetComponent<Rigidbody>();
        stateMachine.Intialize(new BallIdle(this));
    }

    public void Serve()
    {
        ballServeposition = transform.position;
        stateMachine.ChangeState(new BallServe(this));
    }
    private void OnCollisionExit(Collision collision)
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Coll: " + collision.gameObject.name);
        if (isServing && collision.gameObject.name == "Ground")
        {
            //rb.useGravity = false;
            ballDirectionUp = true;
            ballDirectionDown = false; ;
            ballGroundposition = transform.position;
        }

        if (isServing && collision.gameObject.name == "Hand_Right")
        {
            //rb.useGravity = false;
            ballDirectionUp = false;
            ballDirectionDown = true;
            rb.velocity += new Vector3(0f, 1f, 0f);
            ballGroundposition = transform.position;
        }


    }
    private void Update()
    {
        stateMachine.currentState.Update();

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button1) && iCanSpawnBall)
        {
            transform.position = ballPoint.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            ballServeposition = transform.position;
            Invoke("CoolDown", 0.2f);
        }
    }

    void CoolDown()
    {
        iCanSpawnBall = true;
    }

}

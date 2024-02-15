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
    public GameObject hand;
    Vector3 lastVelocity;
    public float speedFactor;
    public Rigidbody rb;
    public static bool isServing;
    public static bool isAttacking;
    public static bool isIdle;
    public static bool isHitting;

    public static bool returnBall;
    public static bool ballDirectionUp;
    public static bool ballDirectionDown;
    [SerializeField] Transform ballPoint;
    public float ballServeSpeed = 0.1f;
    public static bool iCanSpawnBall = true;
    public Transform ballServeposition;
    public Vector3 ballGroundposition;
    public Vector3 prevvel;
    public Vector3 refelct;
    public Vector3 direction;
    public Transform stop;
    public float ballAttackSpeed;
    // Start is called before the first frame update
    public float bounceSpeed = 5f; // Adjust this value to change the bounce speed
    public float amplitude = 1f;
    public float groundBounce;
    [Range(0, 0.9f)] public float velocityCoeff;
    public bool IsTouchWall;
    public Vector3 initialPosition;
    void Start()
    {
        stateMachine = new StateMachine();
        rb = GetComponent<Rigidbody>();
        stateMachine.Intialize(new BallIdle(this));
    }

    public void Serve()
    {
        stateMachine.ChangeState(new BallServe(this));
    }

    public void Idle()
    {
        stateMachine.ChangeState(new BallIdle(this));
    }
    private void OnCollisionExit(Collision collision)
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isServing && collision.gameObject.name == "Hand_Right" && RayfromHand.isHandOnGround)
        {

        }
        if (collision.transform.name == "WALL1")
        {
            IsTouchWall = true;
        }
        else if (/*isServing &&*/ collision.gameObject.name == "Hand_Right" && !RayfromHand.isHandOnGround)
        {
            stateMachine.ChangeState(new BallAttack(this));
            isServing = false;
        }


        else if (isAttacking && collision.gameObject.name == "Hand_Right")
        {
            //ContactPoint cp = collision.contacts[0];
            //Vector3 testvector = Vector3.Reflect(cp.normal, Vector3.forward);
            rb.AddForce(hand.transform.up * ballAttackSpeed * UxrAvatar.LocalAvatar.GetGrabber(UxrHandSide.Right).Velocity.magnitude);
            //rb.AddForce(testvector*-10f);
            //print("testvecor: " + testvector);
            //rb.velocity = Vector3.Reflect(lastVelocity * (-500), cp.normal);

        }

        else if (isAttacking && collision.gameObject.tag.Contains("Ground"))
        {
            //rb.AddForce(transform.forward * groundBounce);
            stateMachine.Intialize(new BallHitting(this));
            isAttacking = false;
            isHitting = true;
            Vector3 dir = prevvel - collision.contacts[0].point;
            refelct = Vector3.Reflect(dir, collision.contacts[0].normal);
            direction = hand.transform.position - transform.position;
            direction.x = 0;
            direction.y = 0;

        }


    }

    private void Update()
    {
        stateMachine.currentState.Update();
        prevvel = rb.velocity;
        print("Vasyavel" + rb.velocity.magnitude);

        
        //Vector3 direction = hand.transform.position - transform.position;
        //Vector3 vel = rb.velocity;
        //vel.x = Mathf.Clamp(vel.x, 0f, 2);
        //vel.y = Mathf.Clamp(vel.x, 0f, 2);
        ////direction.z = 0f;
        //rb.velocity = vel;
        //direction.x = Mathf.Clamp(direction.x, -5, 5);
        // rb.AddForce(direction * 0.01f);

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button1) && iCanSpawnBall)
        {
            Serve();
            Invoke("CoolDown", 0.2f);
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button2) && iCanSpawnBall)
        {
            stateMachine.ChangeState(new BallIdle(this));
            Invoke("CoolDown", 0.2f);
            IsTouchWall = false;
        }
    }

    void CoolDown()
    {
        iCanSpawnBall = true;
    }

}

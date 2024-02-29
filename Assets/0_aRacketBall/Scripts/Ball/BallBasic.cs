using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class BallBasic : MonoBehaviour
{
    StateMachine stateMachine;
    public float ballSpeed;
    public GameObject hand;
    public GameObject player;
    public GameObject wall;
    public float speedFactor;
    public Rigidbody rb;
    public static bool returnBall;
    public static bool ballDirectionUp;
    public static bool ballDirectionDown;
    public GameObject corridorY1;
    public GameObject corridorY2;
    //[SerializeField] Transform ballPoint;
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
    //[Range(0, 0.9f)] public float velocityCoeff;
    //[Range(0, 1)] public float velocityUpCoeffBpunce;
    //public bool IsTouchWall;
    public Vector3 initialPosition;
    public Vector3 wallTouchPosition;

    public float minvelocity;
    public float attackUpForce;
    public float floorBounceyUpForce;
    public float floorBounceyForce;
    public float maxvelocity;
    public float serveVelocity;
    public Transform serveAssistDot;
    public Transform hitAssistDot;
    public Transform hitAssistDot1;

    public GameObject floor;
    public bool raycastCheck;
    public bool runAfterHit;

    //public bool runAfterHitDown;
    //public bool runAfterHitUp;

    //public bool addZ;
    //public bool rmZ;

    public bool goLeft;
    public bool goRight;

    //public bool WallLeftTouch;
    //public bool WallRightTouch;

    //public float wTouch;

    public float toPlayer;

    public Vector3 LeftControllerVelocity;
    public Vector3 RightControllerVelocity;

    public enum BallPlayerStatus
    {
        isServing, isAttacking, isIdle, isWall, isHitting
    }

    public BallPlayerStatus status;

    [SerializeField] GameObject roundManagerHolder;
    RoundManager roundManager;



    void Start()
    {
        stateMachine = new StateMachine();
        rb = GetComponent<Rigidbody>();
        stateMachine.Intialize(new BallIdle(this));
        roundManager = roundManagerHolder.GetComponent<RoundManager>();
        //oppBase = GameObject.Find("Opponent").GetComponent<OppBase>();

        //  previousPosition = InputTracking.GetLocalPosition(RightControllerDevice.);
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
        print("collided with: " + collision.gameObject.name);

        if (collision.gameObject.name == "PlayerHandRight")
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 direction = contact.point - transform.position;
            if (Vector3.Dot(direction, transform.right) < 0)
            {
                // Apply force to the ball to the left
                goLeft = true;
                goRight = false;
            }
            else
            {
                goRight = true;
                goLeft = false;
            }
            stateMachine.ChangeState(new BallAttack(this));
        }



        else if (collision.transform.name == "WALL1")
        {
            //IsTouchWall = true;
            ContactPoint contact = collision.contacts[0];
            wallTouchPosition = contact.point - wall.transform.position;

            //wTouch = Vector3.Dot(wallTouchPosition, transform.right);

            //if (wTouch < 0)
            //{
            //    // Apply force to the ball to the left
            //    //WallRightTouch = true;
            //    //WallLeftTouch = false;
            //}
            //else
            //{
            //    //WallLeftTouch = true;
            //    //WallRightTouch = false;
            //}
            stateMachine.ChangeState(new BallWall(this));
        }




        else if (status == BallPlayerStatus.isWall && collision.gameObject.tag.Contains("Ground"))
        {
            //rb.AddForce(transform.forward * groundBounce);
            stateMachine.Intialize(new BallHitting(this));
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
        UpdateInput();

        if (Input.GetKeyDown(KeyCode.JoystickButton0) && iCanSpawnBall)
        {
            Serve();
            Invoke("CoolDown", 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1) && iCanSpawnBall)
        {
            stateMachine.ChangeState(new BallIdle(this));
            Invoke("CoolDown", 0.2f);
            //IsTouchWall = false;
        }
    }

    public void UpdateInput()
    {
 
        InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.deviceVelocity, out LeftControllerVelocity);
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.deviceVelocity, out RightControllerVelocity);
        //print(LeftControllerVelocity.magnitude + " " + RightControllerVelocity.magnitude + " magnitude");
    }

    void CoolDown()
    {
        iCanSpawnBall = true;
    }

}

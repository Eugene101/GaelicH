using System.Collections;
using System.Collections.Generic;
using UltimateXR.Core;
using UnityEngine;
using UltimateXR.Haptics;
using UltimateXR.Avatar;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public static bool isInRestrictedArea;
    public float start_coeff;
    float rnd;
    float rnd_x;
    int randDir;
    float randPower;
    public float ballStartForce;
    public static float ballPositionY;
    public float maxSpeed = 25f;
    public static float k_sin = 5f;
    public static bool ballIsOut;
    public float border_coeff = 1f;
    public float maxAngularVelocity = 1f;
    public float maxAngularVelocityCoeff = 1f;
    public float dir_cng = 10f;
    public static bool ballInmove;
    public static bool addShift;
    PlayerController playercontroller;
    GoalController goalController;
    Vector3 viewDirectionBall;
    public GameObject[] ballStartDirections;
    public GameObject EnemyGoalsFix;
    public GameObject PlayerGoalsFix;
    public Transform ballOutPosition;
    Vector3 enemyTarget;
    public EnemyBasic enemyBasic;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        goalController = GameObject.Find("CommonControllers").GetComponent<GoalController>();
        enemyBasic = GameObject.Find("Enemy").GetComponent<EnemyBasic>();
        ballPositionY = 0.5f;
        randDir = -1;
        Ball_start();
    }

    private void Ball_start()
    {
        int startDirection = Random.Range(0, ballStartDirections.Length);
        Vector3 startPos = new Vector3(ballStartDirections[startDirection].transform.position.x, transform.position.y, ballStartDirections[startDirection].transform.position.z);
        transform.LookAt(startPos);
        //InvokeRepeating("MoveBall", 2f, 0.05f);
        Invoke("MoveBall", 0.5f);
        ballIsOut = false;
    }

    public void MoveBall()
    {
        ballInmove = true;
        ballIsOut = false;
    }

    public void StopBall()
    {
        ballInmove = false;
        ballIsOut = true;
    }


    void Update()
    {

        if (transform.position.y != ballPositionY)
        {
            transform.position = new Vector3(transform.position.x, ballPositionY, transform.position.z);
        }

        if (ballInmove && !PlayerController.playerShoot)
        {
            rnd = Random.Range(0, 90);
            Vector3 shift = new Vector3(Mathf.Sin(rnd), 0f, Mathf.Sin(rnd) * k_sin);
            rb.AddForce(transform.forward * ballStartForce + shift);
            Vector3 vel = rb.velocity;
        }

        if (PlayerController.playerShoot && addShift)
        {
            if (randDir == 1)
            {
                rb.AddForce(Vector3.forward + new Vector3(-randPower, 0f, 0f));
            }

            else if (randDir == 0)
            {
                rb.AddForce(Vector3.forward + new Vector3(randPower, 0f, 0f));
            }

        }

        if (EnemyBasic.enemyShot)
        {
            transform.position = Vector3.Lerp(transform.position, enemyBasic.SphereTarget.transform.position, 0.01f);
            //transform.Translate(Vector3.forward*0.01f);
        }

    }

    public void EnemyShoot(Vector3 shotTarget)
    {
        enemyTarget = shotTarget;
        EnemyBasic.enemyShot = true;
    }

    public void HideBall()
    {
        //ballIsOut = true;
        StopBall();
        transform.position = ballOutPosition.position;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        rb.angularVelocity = Vector3.zero;
        //rb.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "GoalsArea" && !PlayerController.playerShoot && !EnemyBasic.enemyShot)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Ball_start();
            rb.AddForce(Vector3.forward * 100f);
        }

        if (other.name == "EnemyGoalsFix")
        {
            goalController.PlayerScored();
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
        }

        if (other.name == "PlayerGoalsFix")
        {
            goalController.EnemyScored();
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
        }

        if (other.name == "RestrictedArea" && EnemyBasic.isRestricted)
        {
            enemyBasic.Frozen();
        }

        //if (other.name == "RestrictedArea")
        //{
        //    Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        //}

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "RestrictedArea" && EnemyBasic.isRestricted)
        {
            enemyBasic.Frozen();
        }

       
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.name == "RestrictedArea")
        {
            if (!PlayerController.catchedBall)
            {
                enemyBasic.FollowBall();
            }

            else
            {
                enemyBasic.FollowPlayer();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
   
        if (!collision.gameObject.name.Contains("Ground"))
        {
            if (EnemyBasic.enemyShot && collision.gameObject.name != "Player")
            {
                int startDirection = Random.Range(0, ballStartDirections.Length);
                Vector3 startPos = new Vector3(ballStartDirections[startDirection].transform.position.x, transform.position.y, ballStartDirections[startDirection].transform.position.z);
                transform.LookAt(startPos);
                rb.AddForce(transform.forward * ballStartForce * 1000f);
                EnemyBasic.enemyShot = false;
            }

            else if (EnemyBasic.enemyShot && collision.gameObject.name == "Player")
            {
                EnemyBasic.enemyShot = false;

            }

            if (collision.gameObject.name.Contains("Border") && !EnemyBasic.enemyShot)
            {
                Vector3 opposite_move = -rb.velocity * border_coeff;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(opposite_move);
                PlayerController.playerShoot = false;
                ballInmove = true;
                //transform.rotation = Random.rotation;
                Ball_start();
            }

            if (collision.gameObject.tag == "PlayerBorders")
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Border"))
        {
            Ball_start();
        }
    }

    public void PlayerShoot(Vector3 viewDirection)
    {
        viewDirectionBall = viewDirection;
        rb.AddForce(viewDirection * 1500f);
        Invoke("AddShift", 1f);
        ballInmove = false;
        randDir = -1;
        randPower = 0f;
    }

    void AddShift()
    {

        addShift = true;
        randDir = Random.Range(0, 2);
        randPower = Random.Range(1f, 2.5f);
        //rb.AddTorque(Vector3.right * 5000f);
    }

}

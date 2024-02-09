using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public GameObject SphereTarget;

    public float enemySpeed;
    public float enemyShootAccuracy;
    public float enemyRechargeTime;
    public float enemyHp;
    public float enemyToPlayer;
    public float enemyTendencyToShoot;
    public Transform dontGoHere;
    float currentHealth;
    float currentSpeed;
    public Transform enemyStartPosition;
    public static int enemyStatus;
    public static int bulletNumbers;
    public static bool enemyShot;
    public static bool frozen;
    public static bool isRestricted;
    bool iCanShoot;
    GameObject target;
    public GameObject bullet;
    public Transform shotTarget;
    public float maxAccuracy;
    float shootDotX;
    GameObject ball;
    public GameObject player;
    public GameObject playerCar;
    public GameObject playerGates;
    public GameObject enemyBall;
    public GameObject enemyLose;
    public GameObject EnemyGoFromBehind;
    public GameObject commonControllers;
    GameObject bulletOpp;
    BallController ballscript;
    PlayerController playerController;
    float dist;
    Rigidbody rb;
    LampController lampController;
    //enemyStatus  -1   - stand on place
    //     0 - follow ball
    // 1 - follow player
    // 2 - run with ball to attack

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lampController = commonControllers.GetComponent<LampController>();
        ball = GameObject.Find("Ball");
        ballscript = ball.GetComponent<BallController>();
        playerController = player.GetComponent<PlayerController>();
        Invoke("FollowBall", 2f);
        enemyStatus = -1;
        iCanShoot = true;
        RestoreHealth();
        currentSpeed = enemySpeed;
    }

    public void RestoreHealth()
    {
        currentHealth = enemyHp;
    }

    public void FollowBall()
    {

        target = ball;
        enemyStatus = 0;
        frozen = false;
        currentSpeed = enemySpeed;

    }

    public void Frozen()
    {
        enemyStatus = -1;
        frozen = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void FollowPlayer()
    {

        target = player;
        enemyStatus = 1;
        frozen = false;
        currentSpeed = enemySpeed;
    }

    public void AttackGates()
    {
        target = playerGates;
        lampController.EnableLamps(2);
        enemyStatus = 2;
        frozen = false;
        currentSpeed = enemySpeed / 2;
    }

    private void FixedUpdate()
    {

        if (target != null)
        {
            dist = Vector3.Distance(transform.position, target.transform.position);

            if (enemyStatus == 2 && dist < enemyTendencyToShoot)
            {
                EnemyShoot();
            }

            if (PlayerController.catchedBall && dist < enemyToPlayer)
            {
                Frozen();
                transform.LookAt(player.transform.position);
                EnemyAttackPlayer();
            }

            else if (PlayerController.catchedBall && dist >= enemyToPlayer)
            {
                FollowPlayer();
                //EnemyAttackPlayer();
            }

        }

        if (transform.position.z < dontGoHere.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, dontGoHere.transform.position.z);
        }

        if (enemyStatus != -1)
        {

            transform.LookAt(target.transform.position);
            //transform.position = Vector3.Slerp(transform.position, target.transform.position, enemySpeed);
            transform.Translate(Vector3.forward * currentSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball" && !frozen)
        {
            AttackGates();
            ballscript.HideBall();
            //ball.transform.position = enemyBall.transform.position;
        }

        if (collision.gameObject.name == "Ground")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RestrictedArea")
        {
            isRestricted = true;
        }

        if (other.tag == "Ammo" && enemyStatus == 2)
        {
            //ball.transform.position = enemyBall.transform.position;
            //ballscript.MoveBall();
            //Invoke("Frozen", 1f);
            //Invoke("FollowBall", 2f);
            float damage = other.GetComponent<AmmoBasic>().damage;
            rb.AddForce(Vector3.right * damage * 30f, ForceMode.Impulse);
            Invoke("Frozen", 1f);
            currentHealth -= damage;
            print(currentHealth + " currentHealth");
            if (currentHealth <= 0)
            {
                int rshift = Random.Range(0, 2);
                lampController.DisableLamps();
                Rigidbody ballrb = ball.GetComponent<Rigidbody>();
                if (rshift == 0)
                {
                    ball.transform.position = enemyLose.transform.position - new Vector3(10f, 0f, 10f);
                    ballrb.AddForce(Vector3.right, ForceMode.Impulse);
                }

                else
                {
                    ball.transform.position = enemyLose.transform.position + new Vector3(10f, 0f, 10f);
                    ballrb.AddForce(Vector3.left, ForceMode.Impulse);
                }

                ballscript.MoveBall();
                Invoke("FollowBall", 2f);
                RestoreHealth();
            }

            else
            {
                Invoke("AttackGates", 2f);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RestrictedArea")
        {
            isRestricted = false;
        }
    }

    void EnemyAttackPlayer()
    {

        if (iCanShoot)
        {
            transform.LookAt(player.transform.position);
            bulletOpp = Instantiate(bullet, enemyBall.transform.position, transform.rotation);
            //Rigidbody bulletBody = bulletOpp.GetComponent<Rigidbody>();
            //bulletBody.AddForce(transform.forward * 8f, ForceMode.Impulse);
            iCanShoot = false;
            Invoke("ICanShootAgain", enemyRechargeTime);
            Invoke("AfterShoot", 1f);
        }

    }

    void ICanShootAgain()
    {
        iCanShoot = true;
    }

    void EnemyShoot()
    {
        ball.transform.position = enemyBall.transform.position;
        lampController.DisableLamps();
        float shift = Random.Range(0, maxAccuracy - enemyShootAccuracy);
        int ShotDirection = Random.Range(0, 2); //0 - shoot to left, //1-shot to right
        switch (ShotDirection)
        {
            case 0:
                shootDotX = playerGates.transform.position.x + shift;
                shotTarget.position = new Vector3(shootDotX, BallController.ballPositionY, playerGates.transform.position.z);
                break;
            case 1:
                shootDotX = playerGates.transform.position.x - shift;
                shotTarget.position = new Vector3(shootDotX, BallController.ballPositionY, playerGates.transform.position.z);
                break;
        }
        enemyStatus = -1;
        SphereTarget.transform.position = shotTarget.position;
        transform.LookAt(shotTarget.position);
        ball.transform.LookAt(shotTarget.position);
        ballscript.EnemyShoot(shotTarget.position);
        Frozen();
        Invoke("AfterShoot", 2f);
    }

    void AfterShoot()
    {

        ballscript.MoveBall();
        if (!PlayerController.catchedBall)
        {
            FollowBall();
        }

        else
        {
            FollowPlayer();
        }
    }

}





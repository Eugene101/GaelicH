using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Haptics;

public class PlayerController : MonoBehaviour
{
    public static bool catchedBall;
    public static bool playerShoot;
    public static bool shooted;
    public static bool buttonPressedControl;
    public float SpeedCoeff;
    public Transform playerBallPlace;
    public Transform loseBallpoint;
    GameObject ball;
    public GameObject commonControllers;
    BallController ballscript;
    int pressed = 0;
    public EnemyBasic enemyBasic;
    LampController lampController;


    private void Awake()
    {
      
    }
    void Start()
    {
        lampController = commonControllers.GetComponent<LampController>();
        ball = GameObject.Find("Ball");
        ballscript = ball.GetComponent<BallController>();
        enemyBasic = GameObject.Find("Enemy").GetComponent<EnemyBasic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (catchedBall && other.gameObject.name.Contains("EnemyBullet"))
        {
            ball.transform.position = loseBallpoint.position;
            Rigidbody ballrb = ball.GetComponent<Rigidbody>();
            int rshift = Random.Range(0, 2);
            if (rshift == 0)
            {
                ball.transform.position = loseBallpoint.transform.position - new Vector3(10f, 0f, 10f);
                ballrb.AddForce(Vector3.right, ForceMode.Impulse);
            }

            else
            {
                ball.transform.position = loseBallpoint.transform.position + new Vector3(10f, 0f, 10f);
                ballrb.AddForce(Vector3.left, ForceMode.Impulse);
            }
            ballscript.MoveBall();
            EnemyBasic.enemyStatus = 0;
            enemyBasic.FollowBall();
            lampController.DisableLamps();
            catchedBall = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            ballscript.HideBall();
            catchedBall = true;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
            BallController.ballInmove = false;
            EnemyBasic.enemyShot = false;
            //ball.transform.position = playerBallPlace.transform.position;
            //ball.transform.SetParent(playerBallPlace);
            ball.transform.rotation = transform.rotation;
            enemyBasic.FollowPlayer();
            enemyBasic.RestoreHealth();
            lampController.EnableLamps(1);

        }
    }

    void FixedUpdate()
    {
        //UltimateXR.Locomotion.UxrSmoothLocomotion.k = SpeedCoeff;

        //transform.LookAt (UxrAvatar.LocalAvatar.CameraForward);
        // if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Right, UxrInputButtons.Button1) && !shooted && catchedBall)

        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Right, UxrInputButtons.Button1) && !shooted && catchedBall)
        {
            pressed++;
            if (pressed == 1)
            {
                PlayerShootBall();
            }

        }



        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Right, UxrInputButtons.Button2) && !buttonPressedControl)
        {
            buttonPressedControl = true;
            Invoke("buttonPressedControlOff", 0.1f);
            Rigidbody rb = ball.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            ball.transform.position = transform.position;

        }
    }

    public void buttonPressedControlOff()
    {
        buttonPressedControl = false;
    }

    void PlayerShootBall()
    {
        if (pressed == 1)
        {
            pressed++;
            catchedBall = false;
            playerShoot = true;
            lampController.DisableLamps();
            shooted = true;
            ball.transform.position = playerBallPlace.transform.position;
            ball.transform.rotation = transform.rotation;
            Vector3 viewDirection = UxrAvatar.LocalAvatar.CameraForward;
            ballscript.PlayerShoot(viewDirection);
            enemyBasic.FollowBall();
            ballscript.MoveBall();
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
        }

        Invoke("PressedReset", 2f);

    }



    void PressedReset()
    {
        pressed = 0;
        shooted = false;
    }
}
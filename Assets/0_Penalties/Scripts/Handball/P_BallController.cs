using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class P_BallController : MonoBehaviour
{
    [SerializeField] Transform ballPoint;
    [SerializeField] GameObject ball;
    [SerializeField, Range(0, 10)] int ballCooldown;
    public GameObject cloth;
    Clothcode clothcode;
    public static bool iCanSpawnBall = true;
    public static bool ballIsInGame;
    GameManager gameManager;
    

    private void Start()
    {
        clothcode = cloth.GetComponent<Clothcode>();
    }


    void FixedUpdate()
    {
        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button1) && iCanSpawnBall)
        {
            //GameObject oldBall = GameObject.FindGameObjectWithTag("Ball");
            //Destroy(oldBall);
            //GameObject playerBall = Instantiate(ball, ballPoint.position, Quaternion.identity);
            //playerBall.tag = "Ball";
            //clothcode.findBall();
            //iCanSpawnBall = false;
            //Invoke("CoolDown", ballCooldown);
            ball.transform.position = ballPoint.position;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
           
        }

    }

    void CoolDown()
    {
        iCanSpawnBall = true;
    }
}

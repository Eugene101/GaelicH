using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Manipulation;
using UnityEngine;
//using UltimateXR.Avatar;
//using UltimateXR.Core;
//using UltimateXR.Devices;

public class PlayerBallController : MonoBehaviour
{
    [SerializeField] Transform ballPoint;
    [SerializeField] GameObject ball;
    [SerializeField, Range(0, 10)] int ballCooldown;
    public static bool iCanSpawnBall = true;


    void FixedUpdate()
    {
        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button1) && iCanSpawnBall)
        {
            GameObject oldBall = GameObject.FindGameObjectWithTag("playerBall");
            Destroy(oldBall);
            GameObject playerBall = Instantiate(ball, ballPoint.position, Quaternion.identity);
            playerBall.tag = "playerBall";
            iCanSpawnBall = false;
            Invoke("CoolDown", ballCooldown);
        }

    }

    void CoolDown()
    {
        iCanSpawnBall = true;
    }
}

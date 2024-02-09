using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;


public class BallReturn : MonoBehaviour
{
    bool wasPressed;
    [SerializeField] GameObject ball;
    [SerializeField] Transform ballTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasPressed && UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button1))
        {
            wasPressed = true;
            ReturnBall();
        }
    }

    void ReturnBall()
    {
        ball.transform.position = ballTransform.position;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        Invoke("ResetBool", 1f);
    }

    void ResetBool()
    {
        wasPressed = false;
    }    
}

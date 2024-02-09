using System.Collections;
using System.Collections.Generic;
using UltimateXR.Core.Components.Composite;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class BallFly : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed;
    Vector3 lastVelocity;
    public float speedFactor;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //print("collision.name " + collision.gameObject.name);
        //if (collision.gameObject.name == "Hand_Right")
        //{
        //    //rb.AddForce(collision.GetContact(0).normal * ballSpeed/*, ForceMode.Impulse*/);
        //    //rb.useGravity = true;
        //    print("Shoot");
        //}

        //if (ManipulationsDetectorBall.ballReleased)
        //{
            rb.useGravity = true;
            float speed = lastVelocity.magnitude;
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
           // Vector3 Refl = Vector3.Reflect(direction.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed* speedFactor;
            
        //}
        if(collision.transform.name == "Right_Hand" && !ManipulationsDetectorBall.ballGrabbed)
        {

        }
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("other.name " +  other.name);

    //}
}

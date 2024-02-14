using System.Collections;
using System.Collections.Generic;
using UltimateXR.Core.Components.Composite;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class BallFly : MonoBehaviour
{
    Rigidbody Rigidbody;
    public Vector3 StartPos;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartPos = transform.position;
    }
    float maxVerticalDistance = 1;
    float maxHorizontalDistance = 0.1f;
    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.contacts[0].normal.y);
        //if (collision.contacts[0].normal.y < 0)
        //{
        //    Rigidbody.AddForce(-collision.transform.up * 5, ForceMode.Impulse);
        //    return;
        //}
        Vector3 D = (this.transform.position - StartPos).normalized;
        Vector3 refl = Vector3.Reflect(D, collision.contacts[0].normal);
        Vector3 reflectedForce = new Vector3(
    refl.x * Mathf.Clamp(Mathf.Abs(StartPos.x - this.transform.position.x), 0f, maxHorizontalDistance),
    refl.y * Mathf.Clamp(Mathf.Abs(StartPos.y - this.transform.position.y), 0f, maxVerticalDistance),
    refl.z * Mathf.Clamp(Mathf.Abs(StartPos.z - this.transform.position.z), 0f, maxHorizontalDistance)
);
        Rigidbody.AddForce(reflectedForce * (StartPos - this.transform.position).magnitude, ForceMode.Impulse);
    }
    void Update()
    {


        Vector3 reflectedForce = new Vector3(
    Rigidbody.velocity.x * Mathf.Clamp(Mathf.Abs(StartPos.x - this.transform.position.x), 0f, maxHorizontalDistance),
    Rigidbody.velocity.y,
     Rigidbody.velocity.z * Mathf.Clamp(Mathf.Abs(StartPos.z - this.transform.position.z), 0f, maxHorizontalDistance)
);


        Rigidbody.velocity = reflectedForce;
    }
}

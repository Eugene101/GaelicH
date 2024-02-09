using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Ball : MonoBehaviour
{
    public static bool isNearOpponent;
    Tableau tableau;
    bool playerCanScore = true;
    bool canInvokeJumping = true;

    private void Start()
    {
        tableau = GameObject.Find("Tableau").GetComponent<Tableau>();
    }

    private void OnCollisionEnter(Collision collision)
    {   //if (collision.gameObject.tag != "Player")
        //{
        //    Invoke("KillPlayerBall", 5f);
        //    PlayerBallController.iCanSpawnBall = true;
        //}

        if (collision.gameObject.name.Contains("EnemyGoalsFix"))
        {
            print("Goal!");
            tableau.PlayerScore();
            Rigidbody rb = GetComponent<Rigidbody>();
            //rb.isKinematic = true;
            //rb.useGravity = true;

            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("VasyaTrig" + other.gameObject.name);

        if (other.name.Contains("EnemyGoalsFix"))
        {
            print("GoalTrigger!");
            tableau.PlayerScore();
           
        }
    }
}

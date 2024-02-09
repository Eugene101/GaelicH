using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBots : BotStatePattern
{
    enum Moving
    {
        forward, backward, left, right
    };
    Moving moving;
    bool iCanMove;
    bool newAttempt;
    float destinationRadius = 2.0f;
    float movingSpeed = 0.04f;
    Vector3 target;
    int animationNumber = 0;
    public GameObject TargetSphere;
    private void Start()
    {
        anim = GetComponent<Animator>();
        TargetSphere = GameObject.Find("TargetSphere");
    }

    public void SetRandomDestination()
    {
        newAttempt = true;
        int rnd = Random.Range(0, 4);
        int randomDestination = Random.Range(0, 4);
        float range = Random.Range(3f, 5f);
        switch (rnd)
        {
            case 0: 
                moving = Moving.forward;
                break;
            case 1: 
                moving = Moving.backward;
                break;
            case 2: 
                moving = Moving.left;
                break;
            case 3: 
                moving = Moving.right;
                break;

        }
        RunBot(randomDestination, range);
    }


    void RunBot(int randomDestination, float range)
    {

        switch (moving)
        {
            case Moving.forward: //0
                Debug.Log("moving Forward");
                target = transform.position + new Vector3(0, 0f, -range);
                animationNumber = 1;
                CheckObstacles(target);
                break;

            case Moving.backward: //1
                Debug.Log("moving Down");
                target = transform.position + new Vector3(0, 0f, range);
                animationNumber = 2;
                CheckObstacles(target);
                break;
            case Moving.left: //2
                Debug.Log("moving Left");
                target = transform.position + new Vector3(-range, 0f, 0);
                animationNumber = 3;
                CheckObstacles(target);
                break;
            case Moving.right: //3
                Debug.Log("moving Right");
                animationNumber = 4;
                target = transform.position + new Vector3(range, 0f, 0);
                CheckObstacles(target);
                break;

        }
    }

    void CheckObstacles(Vector3 target)
    {

        Collider[] colliders = Physics.OverlapSphere(target, destinationRadius);
        foreach (Collider collider in colliders)
        {

            if (collider.transform.tag == "PlayerBorders")
            {
                Debug.Log("There is something near the destination area. " +collider.transform.position);
                if (newAttempt == true)
                {
                    newAttempt = false;
                    SetRandomDestination();
                }
                break;
            }

            else
            {
                iCanMove = true;
                anim.SetInteger("EnemyBehavoir", animationNumber);
                Debug.Log("There is nothing near the destination area.");
            }
        }
    }
    private void FixedUpdate()
    {
        var dist = Vector3.Distance(transform.position, target);
        TargetSphere.transform.position = target;
        if (iCanMove)
        {
            transform.position = Vector3.Lerp(transform.position, target, movingSpeed);
        }

        if (iCanMove && dist < 0.1f)
        {
            iCanMove = false;
            Idle();
        }
    }

}
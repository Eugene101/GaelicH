using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttack : BotStatePattern
{
    GameObject enemyBall;
    Transform enemyBallparent;
    Transform enemyBallposition;
    GameObject currentBall;

    void Start()
    {
        foreach (Transform childrens in transform.GetComponentsInChildren<Transform>())
        {
            if (childrens.name == "RightHand")
            {
                enemyBallparent = childrens;
                break;
            }
        }

        enemyBall = GameObject.Find("EnemyBall");
        anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        GameObject enemyBallLoaded = Instantiate(enemyBall, enemyBallparent.position, Quaternion.identity);
        enemyBallLoaded.transform.parent = enemyBallparent;
        currentBall = enemyBallLoaded;
        anim.SetInteger("EnemyBehavoir", 5);
        Invoke("ThrowBall", 1.28f);
    }

    void ThrowBall()
    {
        currentBall.transform.SetParent(null);
        Invoke("Idle", 0.5f);
    }
}

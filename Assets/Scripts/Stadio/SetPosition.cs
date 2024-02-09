using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Haptics;

public class SetPosition : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject ball;
    public GameObject playerPos;
    public GameObject enemyPos;
    public GameObject ballPos;
    EnemyBasic enemyBasic;
    PlayerController playerController;
    public GameObject playerCar;
    LampController lampController;
    // Start is called before the first frame update
    void Start()
    {
        enemyBasic = GameObject.Find("Enemy").GetComponent<EnemyBasic>();
        playerController = player.GetComponent<PlayerController>();
        lampController = GetComponent<LampController>();
        SetPos();
    }

    public void SetPos()
    {
        UxrManager.Instance.MoveAvatarTo(UxrAvatar.LocalAvatar, playerPos.transform.position);
        enemy.transform.position = enemyPos.transform.position;
        //enemy.transform.rotation = Quaternion.Euler(-90f, 90f, 90f);
        //enemy.transform.rotation = transform.rotation;
        ball.transform.position = ballPos.transform.position;
        lampController.DisableLamps();
       
        if (enemyBasic != null)
        {
            enemyBasic.RestoreHealth();
        }

    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    //if (ball.transform.position.y < ballPos.transform.position.y)
    //    //{
    //    //    ball.transform.position = new Vector3(ball.transform.position.x, ballPos.transform.position.y, ball.transform.position.z);
    //    //}
    //}
}

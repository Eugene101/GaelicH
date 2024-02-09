using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPoint : MonoBehaviour
{
    RivalsController rivalsController;
    public GameObject enemy;
    GoalController goalController;
    public GameObject[] rivalsPrefabs;
    public RuntimeAnimatorController animDriving;
    public Transform pilotPoint;
    GameObject driver;

    private void Awake()
    {
        goalController = GameObject.Find("CommonControllers").GetComponent<GoalController>();
        //var rivalsController = GameObject.Find("RivalsController");

        GameObject enemyDriver = Instantiate(rivalsPrefabs[PlayerPrefs.GetInt("IntValue")], pilotPoint.transform.position, enemy.transform.rotation*=Quaternion.Euler(0f,180f,0f));
        enemyDriver.transform.localScale *= 1.5f;
        //enemyDriver.transform.SetParent(enemy);
        //var rb = enemyDriver.GetComponent<Rigidbody>();
        //Destroy(rb);
        //var kkk = enemyDriver.GetComponent<SphereCollider>();
        //Destroy(kkk);
        var anim = enemyDriver.GetComponent<Animator>();
        anim.runtimeAnimatorController = animDriving;
        driver = enemyDriver;
        //enemyDriver.AddComponent(anim);
        //enemy.AddComponent(anim);


        if (PlayerPrefs.GetString("StringValue") != null)
        {
            goalController.oppName.text = PlayerPrefs.GetString("StringValue");
        }

        else
        {
            goalController.oppName.text = ("Vasya");
        }
        
        

            //if (MainMenu.competitions == Competitions.Match)
            //{
            //    
            //}

        //else if (MainMenu.competitions == Competitions.League)
        //{

        //}

        //else if (MainMenu.competitions == Competitions.Championship)
        //{

        //}

    }

    private void Update()
    {
        driver.transform.position = pilotPoint.transform.position;
        driver.transform.rotation = pilotPoint.transform.rotation;
    }


}

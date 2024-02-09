using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamsController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int gameMode;
    [SerializeField] GameObject[] players;
    [SerializeField] Transform[] enemyDots;
    [SerializeField] Transform[] playerdots;
    [SerializeField] RuntimeAnimatorController[] enemiesAnimatorControllers;

    void Start()
    {
        LoadPlayers();
    }

    void LoadPlayers()
    {
        if (gameMode == 0)
        {
            int randEnemy = Random.Range(0, players.Length);
            GameObject Enemy = Instantiate(players[randEnemy], enemyDots[0].position, Quaternion.Euler(0f, 180f, 0f));
            Enemy.tag = "Enemy";
            Enemy.transform.localScale *= 1.25f;
            Enemy.GetComponent<Animator>().runtimeAnimatorController = enemiesAnimatorControllers[0];
            Enemy.AddComponent<BotStatePattern>();
            Enemy.AddComponent<MovingBots>();
            Enemy.AddComponent<BotAttack>();
            Enemy.AddComponent<BotJumping>();
        }

        //else if (gameMode == 1)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        int randEnemy = Random.Range(0, players.Length);
        //        GameObject Enemy = Instantiate(players[randEnemy], enemyDots[i].position, Quaternion.Euler(0f, 180f, 0f));
        //        Enemy.tag = "Enemy";
        //        Enemy.GetComponent<Animator>().runtimeAnimatorController = enemiesAnimatorControllers[0];
        //        Enemy.AddComponent<BotStatePattern>();
        //        Enemy.AddComponent<MovingTeamMate>();
        //        Enemy.AddComponent<TeamMateAttack>();
        //    }

        //for (int i = 0; i < 2; i++)
        //{
        //    int randEnemy = Random.Range(0, players.Length);
        //    GameObject TeamMate = Instantiate(players[randEnemy], playerdots[i].position, transform.rotation);
        //    TeamMate.tag = "TeamMate";
        //    TeamMate.GetComponent<Animator>().runtimeAnimatorController = enemiesAnimatorControllers[0];
        //    TeamMate.AddComponent<BotStatePattern>();
        //    TeamMate.AddComponent<MovingTeamMate>();
        //    TeamMate.AddComponent<TeamMateAttack>();

        //}

    }

}

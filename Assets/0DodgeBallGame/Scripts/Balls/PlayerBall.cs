using Oculus.Platform;
using UltimateXR.Core;
using UltimateXR.Manipulation;
using UnityEngine;
using UltimateXR.Avatar;
using Unity.VisualScripting;

public class PlayerBall : MonoBehaviour
{
    public static bool isNearOpponent;
    Tableau tableau;
    bool playerCanScore = true;


    private void Start()
    {
        tableau = GameObject.Find("Tableau").GetComponent<Tableau>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Invoke("KillPlayerBall", 5f);
            PlayerBallController.iCanSpawnBall = true;
        }

        if (collision.gameObject.tag == "Enemy" && playerCanScore)
        {
            tableau.PlayerScore();
            playerCanScore = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gates_net")
        {
            tableau.PlayerScore();
        }
    }

    void KillPlayerBall()
    {
        Destroy(gameObject);
    }




}

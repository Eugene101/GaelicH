using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    public float enemyBallSpeed;
    GameObject player;
    bool letsGo;
    bool Icanscore = true;
    bool setTagret = false;
    //public GameObject targetBall;
    Vector3 target;
    public GameObject Tableau;
    Tableau tableau;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.Find("BodyGeo");
        tableau = Tableau.GetComponent<Tableau>();

        //foreach (GameObject go in GameObject.FindGameObjectsWithTag("TeamMate"))
        //{
        //    playerBuddies.Add(go);
        //}
    }

    void FixedUpdate()
    {
        if (transform.parent == null && !setTagret)
        {
            SetTarget();
            setTagret = true;
        }

        if (transform.parent == null && letsGo)
        {
            transform.position = Vector3.Lerp(transform.position, target, enemyBallSpeed);
        }
    }

    void SetTarget()
    {
        float shiftx = Random.Range(-2, 2);
        float shiftz = Random.Range(-2, 2);
        target = player.transform.position + new Vector3(shiftx, 0f, shiftz);
        letsGo = true;
        Invoke("AddRb", 0.5f);
    }

    void AddRb()
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "Enemy")
        {
            Invoke("KillBall", 5f);
            letsGo = false;
            setTagret = false;
        }

        if (collision.gameObject.tag == "Player" && Icanscore)
        {
            tableau.OppScore();
            Icanscore = false;
        }
    }

    void KillBall()
    {
        Destroy(gameObject);
    }
}

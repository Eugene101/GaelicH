using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMateBall : MonoBehaviour
{
    public float teamMateBallSpeed;
    List<GameObject> Enemies = new List<GameObject>();
    bool letsGo;
    bool setTagret = false;
    //public GameObject targetBall;
    Vector3 target;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
     
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Enemies.Add(go);
        }
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
            transform.position = Vector3.Lerp(transform.position, target, teamMateBallSpeed);
        }

    }

    void SetTarget()
    {
        int whoIsTarget = Random.Range(0, 3);
        Vector3 shift = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        switch (whoIsTarget)
        {
            case 0:
                target = Enemies[0].transform.position + shift;
                break;
            case 1:
                target = Enemies[1].transform.position + shift;
                break;
            case 2:
                target = Enemies[2].transform.position + shift;
                break;
        }
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

        if (collision.gameObject.tag != "TeamMate")
        {
            Invoke("KillBall", 5f);
            letsGo = false;
            setTagret = false;
        }
    }

    void KillBall()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class LaserPointerScope : MonoBehaviour
{
    //LineRenderer laserLineRenderer;
    //public GameObject laserLine;
    public static bool isFindTarget;
    public GameObject enemyLighting;

    //public GameObject scope;

    void Start()
    {
        //laserLineRenderer = laserLine.GetComponent<LineRenderer>();
        //laserLineRenderer.tag = "laserLineRenderer";
        //gameObject.material.color = Color.red;
        //laserLineRenderer.SetPosition(0, this.transform.position);
        enemyLighting = GameObject.FindGameObjectWithTag("EnemyLighting");
        //enemyLighting.GetComponent<MeshRenderer>().enabled = false;
        enemyLighting.SetActive(false);
    }

    void Update()
    {
        //isFindTarget = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {

            if (hit.collider)
            {
                gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, hit.distance));

                GameObject Target = hit.collider.gameObject;
                print(hit.collider.name + "_target");

                if (Target.name == "Enemy")
                {
                    //enemyLighting.GetComponent<MeshRenderer>().enabled = true;
                    enemyLighting.SetActive(true);
                }

                else
                {
                    enemyLighting.SetActive(false);
                }
                

                //if (Target.name.Contains("Drone"))
                //{
                //    Drone script = Target.GetComponent<Drone>();
                //    script.rend.material.color = Color.green;
                //    script.rend1.material.color = Color.green;
                //    laserLineRenderer.material.color = Color.green;
                //    isFindTarget = true;
                //}

                //else
                //{
                //    isFindTarget = false;
                //}

            }

        }
        else
        {
            isFindTarget = false;
            print("_target IS ABSENT");
            enemyLighting.SetActive(true);
            //enemyLighting.GetComponent<MeshRenderer>().enabled = false;
            //laserLineRenderer.SetPosition(1, new Vector3(0, 0, 5000));
            //laserLineRenderer.material.color = Color.red;
        }
    }


}
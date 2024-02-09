using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Core.Caching;
using UltimateXR.Core.Components;
namespace UltimateXR.Mechanics.Weapons
{
    public class RPG_Rocket : AmmoBasic
    {
        //UxrProjectileSource UxrProjectileSource;
      
        //public float rocketSpeed;

        ////Rigidbody rb;
        //Collider rocketCollider;
        //public GameObject explosion;
        //public EnemyBasic enemyBasic;
        //bool inFly;

        //// Start is called before the first frame update
        //void Start()
        //{
        //    damage = 7f;
        //    //UxrProjectileSource = gameObject.GetComponentInParent<UxrProjectileSource>();
        //    rocketCollider = GetComponent<Collider>();
        //    explosion.gameObject.SetActive(false);
        //    // Update is called once per frame
        //    enemyBasic = GameObject.Find("Enemy").GetComponent<EnemyBasic>();
        //}



        //public void ShotRocket()
        //{
        //    //rb = gameObject.AddComponent<Rigidbody>();
        //    transform.SetParent(null);
        //    //rb.useGravity = false;
        //    inFly = true;
        //    //Vector3 direction = new Vector3(90f, 0f, 90f);
        //    ////Vector3 direction = Vector3.forward;
        //    //rb.AddRelativeForce(direction * rocketSpeed);
        //    //rb.freezeRotation = true;

        //}

        //private void OnTriggerEnter(Collider other)
        //{
        //    print(other.name + " other");
        //    //if (other.gameObject.layer != LayerMask.NameToLayer("Explosible") && inFly) //name of layer is wrong, means "Non-explosible"
        //    //{

        //    if (other.tag != "Player" && inFly)
        //    {
        //        print(other.name + " other");
        //        explosion.gameObject.SetActive(true);
        //        inFly = false;
        //        Destroy(gameObject, 1f);
        //        Destroy(explosion, 1f);

        //        //if (other.tag == "Enemy" && EnemyBasic.enemyStatus == 2)
        //        //{
        //        //    enemyBasic.Frozen();
        //        //    GameObject ball = GameObject.Find("Ball");
        //        //    ball.transform.position = new Vector3(transform.position.x + 2f, 0.5f, transform.position.z + 2f);

        //        //}

        //    }



        //    //}

        //    //if (other.tag == "Player" || other.tag == "Weapon")
        //    //{
        //    //    print("Ignore");

        //    //}

        //    //else
        //    //{
        //    //    explosion.gameObject.SetActive(true);
        //    //    inFly = false;
        //    //    rb.velocity = Vector3.zero;
        //    //    rb.angularVelocity = Vector3.zero;
        //    //    Destroy(explosion, 1f);
        //    //    Destroy(gameObject, 1f);

        //    //}

        //}

        ////private void OnCollisionEnter(Collision collision)
        ////{


        ////    if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Weapon")
        ////    {
        ////        Physics.IgnoreCollision(collision.collider, rocketCollider);
        ////    }


        ////}

        //void Update()
        //{


        //    if (inFly)
        //    {
        //        //rb.AddRelativeForce(-Vector3.left * rocketSpeed);
        //        transform.Translate(-Vector3.left * rocketSpeed);
        //    }


        //}
    }
}
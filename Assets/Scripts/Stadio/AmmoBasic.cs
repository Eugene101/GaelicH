using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBasic : MonoBehaviour
{
    public float damage;
    public static bool inFly;
    GameObject explosion;
    public float ammoSpeed;

    private void Awake()
    {
        explosion = transform.Find("Explosion").gameObject;
        explosion.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inFly)
        {
            if (other.tag != "Player" && !other.name.Contains("ShotGun"))
            {
                print(other.name + "other");
                inFly = false;
                explosion.gameObject.SetActive(true);
                Destroy(gameObject, 3f);
                Destroy(explosion, 3f);
            }
        }

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * ammoSpeed);
    }
}

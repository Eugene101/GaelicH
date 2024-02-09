using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name != "Enemy" && other.gameObject.name != "Ground" && other.gameObject.name != "RestrictedArea")
        //{
        //    print(other.name + " other.name");
        //    //Destroy(gameObject, 0.1f);
        //}

        if (other.gameObject.name == "Player" || other.gameObject.name.Contains("order"))
        {
            Destroy(gameObject, 0.1f);
        }
        
    }


}

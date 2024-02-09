using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothcode : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] colliderSpheres;
    GameObject ball;
    Cloth a;
    //public GameObject pos;
    SkinnedMeshRenderer skin;

    void Start()
    {
        skin = GetComponent<SkinnedMeshRenderer>();

        //skin.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, pos.transform.position.z);

        /*transform.position = pos.transform.position;*/
        List<ClothSphereColliderPair> clothColliders = new List<ClothSphereColliderPair>();
        Cloth a = GetComponent<Cloth>();
        // balls = GameObject.FindGameObjectsWithTag("ball_generated");
        ball = GameObject.FindGameObjectWithTag("Ball");
        
        clothColliders.Add(new ClothSphereColliderPair(ball.GetComponent<SphereCollider>())); //keep adding colliders from objects tagged Hand
        a.sphereColliders = clothColliders.ToArray();
        
        
        
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Invoke("Reset", 0.5f);
        }
    }


    private void Reset()
    {
        GetComponent<Cloth>().ClearTransformMotion();
       
    }

    public void findBall()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
}

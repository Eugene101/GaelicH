using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothQuake : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    GameObject[] colliderSpheres;
    GameObject[] balls;
    Cloth cloth;
    public GameObject pos;
    [SerializeField] GameObject ball;
    SkinnedMeshRenderer skin;

    void Start()
    {
        //skin = GetComponent<SkinnedMeshRenderer>();
        //List<ClothSphereColliderPair> clothColliders = new List<ClothSphereColliderPair>();
        //cloth = GetComponent<Cloth>();
        //clothColliders.Add(new ClothSphereColliderPair(ball.GetComponent<SphereCollider>())); //keep adding colliders from objects tagged Hand
        //cloth.sphereColliders = clothColliders.ToArray();
    }

        private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "ball")
        {
            Invoke("Reset", 0.5f);
            Rigidbody ball_rb = other.GetComponent<Rigidbody>();
            ball_rb.isKinematic = false;
            ball_rb.useGravity = true;
        }
    }

    private void Reset()
    {
        GetComponent<Cloth>().ClearTransformMotion();
    }

}

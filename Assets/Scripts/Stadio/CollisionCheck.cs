using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    //public Transform leftBorder;
    //public Transform rightBorder;
    //public Transform upBorder;
    //public Transform bottomBorder;
    public GameObject player;
    Vector3 currentPosition;
    bool inBlocker;
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RightBorder" || other.name == "LeftBorder")
        {
            inBlocker = true;
            currentPosition = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RightBorder" || other.name == "LeftBorder")
        {
            inBlocker = false;
        }
    }

    private void FixedUpdate()
    {
        if (inBlocker)
        {
            player.transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
        }
    }

}
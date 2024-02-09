using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    public static bool isInHand;
    public GameObject line;

    private void Start()
    {
        line.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.name.Contains("Toucher"))
        {
            isInHand = true;
            line.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Toucher"))
        {
            isInHand = false;
            line.SetActive(false);
        }
    }

}

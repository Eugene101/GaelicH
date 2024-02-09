using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHandTouch : MonoBehaviour
{
    public bool isInHand;
    public GameObject ScopeLine;

    // Start is called before the first frame update
    void Start()
    {
        //ScopeLine.gameObject.SetActive(false);

    }

    // Update is called once per frame



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Toucher" && gameObject.transform.parent.name.Contains("Shotgun"))
        {
            isInHand = true;
            ScopeLine.gameObject.SetActive(true);
        }



        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.name == "Toucher")
        //    {
        //        isInHand = false;
        //        ScopeLine.gameObject.SetActive(false);
        //    }
        //}


    }
}

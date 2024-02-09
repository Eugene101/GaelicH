using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
    public GameObject cam0, cam1, cube0, cube1;
    // Start is called before the first frame update
    void Start()
    {
        OffOff();
        InvokeRepeating("OnOn", 1f, 7f);
        InvokeRepeating("OffOff", 2f, 6f);
    }


    void OnOn()
    {
        cam0.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cube0.gameObject.SetActive(true);
        cube1.gameObject.SetActive(false);
    }

    void OffOff()
    {

        cam1.gameObject.SetActive(true);
        cam0.gameObject.SetActive(false);
        cube1.gameObject.SetActive(true);
        cube0.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

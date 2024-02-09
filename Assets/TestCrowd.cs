using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCrowd : MonoBehaviour
    
{
    public GameObject Vasya;
    int shift = 1;
    void Start()
    {
        VasyaInst();
    }

    void VasyaInst()
    {
        for (int i = 0; i < 10000; i++)
        {
            shift = i;
            Instantiate(Vasya, new Vector3(i, 0f, 0f), transform.rotation); 
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

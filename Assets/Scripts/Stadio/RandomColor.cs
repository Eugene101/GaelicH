using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    MeshRenderer rend;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();

        if (this.name == "nhouse1")
        {
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }

        else
        {
            for (int i = 0; i < rend.materials.Length; i++)
            {
                //myMaterials.Add(rend.materials[i]);
                rend.materials[i].color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
        }

    }

}

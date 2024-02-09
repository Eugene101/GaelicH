using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpectators : MonoBehaviour
{
    public GameObject[] spectators;
    public GameObject[] dots;
    public Material[] spectatorMats;
    void Start()
    {
        dots = GameObject.FindGameObjectsWithTag("dots");
        if (spectators.Length>=1 && dots.Length>=1)
        {
            SetSpectators();
        }
        else
        {
            print("Spectators not found");
        }
    }

    void SetSpectators()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            int j = Random.Range(0, spectators.Length);
            //GameObject newSpectator = Instantiate(spectators[j], dots[i].transform.position, Quaternion.Euler(0f,-90f,0f));
            GameObject newSpectator = Instantiate(spectators[j], dots[i].transform.position, dots[i].transform.rotation);
            GameObject spectatorsBody = newSpectator.transform.Find("Character").gameObject;
            Material mat = spectatorMats[Random.Range(0, spectatorMats.Length)];
            spectatorsBody.GetComponent<SkinnedMeshRenderer>().material = mat;
        }
    }


}

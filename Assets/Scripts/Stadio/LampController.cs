using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public Color[] lampMaterialColor;
    public Light[] sphereLamps;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void EnableLamps(int lampcolor)
    {
        foreach (var lamps in sphereLamps)
        {
            lamps.enabled = true;
            lamps.color = lampMaterialColor[lampcolor];
        }
    }

    public void DisableLamps()
    {
        foreach (var lamps in sphereLamps)
        {
            lamps.enabled = false;
            lamps.color = lampMaterialColor[0];
        }
    }


}

using UnityEngine;

public class RayfromHand : MonoBehaviour
{
    public static bool isHandOnGround;
    public GameObject sphereTest;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isHandOnGround = true;
        }

        else
        {
            isHandOnGround = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            isHandOnGround = false;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBordersManager : MonoBehaviour
{
    public Transform planeTransform; // Reference to the plane's transform
    public Vector2 rangeX = new Vector2(-5f, 5f); // Range of X coordinates within the plane
    public Vector2 rangeZ = new Vector2(-5f, 5f); // Range of Z coordinates within the plane
    GameObject pointObject;
    void Start()
    {
        InvokeRepeating("PickPoint", 2f, 2f);
    }


    void PickPoint()
    {
        if (pointObject != null) { Destroy(pointObject); }
        // Assuming the plane is oriented along the XY plane
        Vector3 planePoint = planeTransform.position;
        Vector3 planeRight = planeTransform.right;
        Vector3 planeForward = planeTransform.forward;

        // Generate random X and Z coordinates within the specified ranges
        float randomX = Random.Range(rangeX.x, rangeX.y);
        float randomZ = Random.Range(rangeZ.x, rangeZ.y);

        // Calculate the point in world space based on the plane's position and orientation
        Vector3 pointInWorldSpace = planePoint + (planeRight * randomX) + (planeForward * randomZ);

        // Create a sphere GameObject to represent the point
        pointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pointObject.transform.position = pointInWorldSpace;
        pointObject.transform.localScale = Vector3.one * 0.5f; // Adjust size if necessary
    }    
}



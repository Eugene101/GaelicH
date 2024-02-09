using System;
using System.Collections;
using System.Collections.Generic;
using UltimateXR.Core.Components.Composite;
using UltimateXR.Manipulation;
using UnityEngine;

class ManipulationsDetectorBall : UxrGrabbableObjectComponent<ManipulationsDetectorBall>
{
    public static bool ballReleased;
    public static bool ballGrabbed;
    public Action BallRealse;
    public static event Action BallReleased;
    protected override void OnObjectGrabbing(UxrManipulationEventArgs e)
    {
        Debug.Log($"Object {e.GrabbableObject.name} is about to be grabbed by avatar {e.Grabber.Avatar.name}");
    }

    protected override void OnObjectGrabbed(UxrManipulationEventArgs e)
    {
        Debug.Log($"Object {e.GrabbableObject.name} was grabbed by avatar {e.Grabber.Avatar.name}");
        ballGrabbed = true;
    }

    protected override void OnObjectReleasing(UxrManipulationEventArgs e)
    {
        Debug.Log($"Object {e.GrabbableObject.name} is about to be released by avatar {e.Grabber.Avatar.name}");
    }

    protected override void OnObjectReleased(UxrManipulationEventArgs e)
    {
        Debug.Log($"Object {e.GrabbableObject.name} was released by avatar {e.Grabber.Avatar.name}");
        ballReleased = true;
        ballGrabbed = false;
    }


    protected override void OnObjectPlacing(UxrManipulationEventArgs e)
    {
        Debug.Log($"Object {e.GrabbableObject.name} is about to be placed on anchor {e.GrabbableAnchor.name} by avatar {e.Grabber.Avatar.name}");
    }

    protected override void OnObjectPlaced(UxrManipulationEventArgs e)
    {
        Debug.Log($"Object {e.GrabbableObject.name} was placed on anchor {e.GrabbableAnchor.name} by avatar {e.Grabber.Avatar.name}");
    }
}

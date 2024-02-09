using UnityEngine;

namespace UltimateXR.Manipulation
{
    public class ManipulationsDetector : MonoBehaviour
    {
        public UxrGrabbableObject _grabbableObject;

        private void OnEnable()
        {
            _grabbableObject.Grabbing += GrabbableObject_Grabbing;
            _grabbableObject.Grabbed += GrabbableObject_Grabbed;
            _grabbableObject.Releasing += GrabbableObject_Releasing;
            _grabbableObject.Released += GrabbableObject_Released;
            _grabbableObject.Placing += GrabbableObject_Placing;
            _grabbableObject.Placed += GrabbableObject_Placed;
            _grabbableObject.ConstraintsApplying += GrabbableObject_ConstraintsApplying;
            _grabbableObject.ConstraintsApplied += GrabbableObject_ConstraintsApplied;
            _grabbableObject.ConstraintsFinished += GrabbableObject_ConstraintsFinished;
        }

        private void OnDisable()
        {
            _grabbableObject.Grabbing -= GrabbableObject_Grabbing;
            _grabbableObject.Grabbed -= GrabbableObject_Grabbed;
            _grabbableObject.Releasing -= GrabbableObject_Releasing;
            _grabbableObject.Released -= GrabbableObject_Released;
            _grabbableObject.Placing -= GrabbableObject_Placing;
            _grabbableObject.Placed -= GrabbableObject_Placed;
            _grabbableObject.ConstraintsApplying -= GrabbableObject_ConstraintsApplying;
            _grabbableObject.ConstraintsApplied -= GrabbableObject_ConstraintsApplied;
            _grabbableObject.ConstraintsFinished -= GrabbableObject_ConstraintsFinished;
        }

        private void GrabbableObject_Grabbing(object sender, UxrManipulationEventArgs e)
        {
            Debug.Log($"Object {e.GrabbableObject.name} is about to be grabbed by avatar {e.Grabber.Avatar.name}");
        }

        private void GrabbableObject_Grabbed(object sender, UxrManipulationEventArgs e)
        {
            Debug.Log($"Object {e.GrabbableObject.name} was grabbed by avatar {e.Grabber.Avatar.name}");
        }

        private void GrabbableObject_Releasing(object sender, UxrManipulationEventArgs e)
        {
            Debug.Log($"Object {e.GrabbableObject.name} is about to be released by avatar {e.Grabber.Avatar.name}");
        }

        private void GrabbableObject_Released(object sender, UxrManipulationEventArgs e)
        {
            Debug.Log($"Object {e.GrabbableObject.name} was released by avatar {e.Grabber.Avatar.name}");
        }

        private void GrabbableObject_Placing(object sender, UxrManipulationEventArgs e)
        {
            Debug.Log($"Object {e.GrabbableObject.name} is about to be placed on anchor {e.GrabbableAnchor.name} by avatar {e.Grabber.Avatar.name}");
        }

        private void GrabbableObject_Placed(object sender, UxrManipulationEventArgs e)
        {
            Debug.Log($"Object {e.GrabbableObject.name} was placed on anchor {e.GrabbableAnchor.name} by avatar {e.Grabber.Avatar.name}");
        }

        private void GrabbableObject_ConstraintsApplying(object sender, UxrApplyConstraintsEventArgs e)
        {
            Debug.Log($"Object {_grabbableObject.name} is about to be constrained (if required)");
        }

        private void GrabbableObject_ConstraintsApplied(object sender, UxrApplyConstraintsEventArgs e)
        {
            Debug.Log($"Object {_grabbableObject.name} was constrained and can now be constrained using user specific code");
        }

        private void GrabbableObject_ConstraintsFinished(object sender, UxrApplyConstraintsEventArgs e)
        {
            Debug.Log($"All constraints on object {_grabbableObject.name} were applied");
        }
    }
}

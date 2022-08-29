using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace TwoChairs.Interaction
{
    public class TeleportationSitAnchor : BaseTeleportationInteractable
    {
        public event Action SatDown;
        public event Action StoodUp;
        
        [SerializeField]
        [Tooltip("The Transform that represents the teleportation destination.")]
        private Transform _teleportAnchorTransform;

        private bool _isSeatOccupied;

        private void OnValidate()
        {
            if (_teleportAnchorTransform == null)
                _teleportAnchorTransform = transform;
        }


        protected void OnDrawGizmos()
        {
            if (_teleportAnchorTransform == null)
                return;

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_teleportAnchorTransform.position, 0.5f);
            GizmoHelpers.DrawAxisArrows(_teleportAnchorTransform, 0.5f);
            Gizmos.color = Color.white;
        }
        
        protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
        {
            if (_isSeatOccupied)
                return false;
            
            if (_teleportAnchorTransform == null)
                return false;

            teleportRequest.destinationPosition = _teleportAnchorTransform.position;
            teleportRequest.destinationRotation = _teleportAnchorTransform.rotation;
            return true;
        }
    }
}
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace TwoChairs.Network
{
    [RequireComponent(typeof(PhotonView))]
    public class NetworkAvatar : MonoBehaviour
    {
        public Transform Head;
        public Transform LeftHand;
        public Transform RightHand;

        private Transform _headRig;
        private Transform _leftHandRig;
        private Transform _rightHandRig;

        private PhotonView _photonView;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
            FindMainRigs();
            if (_photonView.IsMine)
            {
                DisableRendererForBodyParts();
            }
        }

        private void Update()
        {
            if (_photonView.IsMine)
            {
                MapBodyParts();
            }
        }

        private void DisableRendererForBodyParts()
        {
            foreach (var rendererItem in GetComponentsInChildren<Renderer>())
            {
                rendererItem.enabled = false;
            }
        }

        private void MapBodyParts()
        {
            MapBodyPosition(Head, _headRig);
            MapBodyPosition(LeftHand, _leftHandRig);
            MapBodyPosition(RightHand, _rightHandRig);
        }
        
        private void FindMainRigs()
        {
            XROrigin rig = FindObjectOfType<XROrigin>();
            _headRig = rig.transform.Find("Camera Offset/Main Camera");
            _leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
            _rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
        }

        private void MapBodyPosition(Transform target, Transform rigTransform)
        {
            target.position = rigTransform.position;
            target.rotation = rigTransform.rotation;
        }

        
    }
}
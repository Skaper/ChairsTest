
using System;
using Photon.Pun;
using TwoChairs.Interaction;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace TwoChairs.Environment.Chair
{
    [RequireComponent(typeof(PhotonView))]
    public class Chair : MonoBehaviour
    {
        public TeleportationSitAnchor _sitAnchor;

        private PhotonView _photonView;

        private void OnEnable()
        {
            _sitAnchor.teleporting.AddListener(OnPlayerTeleporting);
        }

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        [PunRPC]
        public void ChairInUse(bool isUse)
        {
            _sitAnchor.enabled = isUse;
        }
        

        private void OnPlayerTeleporting(TeleportingEventArgs teleportingData)
        {
            Debug.Log("Teleporting: " + teleportingData.interactableObject);
            _photonView.RPC("ChairInUse", RpcTarget.AllBufferedViaServer, false);
            _sitAnchor.teleportationProvider.endLocomotion += OnBeginNewLocomotion;
        }

        private void OnBeginNewLocomotion(LocomotionSystem locomotionSystem)
        {
            _sitAnchor.teleportationProvider.endLocomotion -= OnBeginNewLocomotion;
            _sitAnchor.teleportationProvider.beginLocomotion += OnChangePlace;
            
        }
        
        private void OnChangePlace(LocomotionSystem locomotionSystem)
        {
            Debug.Log("Teleporting: out");
            
            _sitAnchor.enabled = true;
            _photonView.RPC("ChairInUse", RpcTarget.AllBufferedViaServer, true);
            _sitAnchor.teleportationProvider.beginLocomotion -= OnChangePlace;
        }

        
    }
}
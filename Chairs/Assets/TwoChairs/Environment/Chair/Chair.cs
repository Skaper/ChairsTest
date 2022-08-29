
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
            _sitAnchor.SatDown += OnPlayerSatDown;
            _sitAnchor.StoodUp += OnPlayerStoodUp;
        }

        private void OnDisable()
        {
            _sitAnchor.SatDown -= OnPlayerSatDown;
            _sitAnchor.StoodUp -= OnPlayerStoodUp;
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
        

        private void OnPlayerSatDown()
        {
            _photonView.RPC("ChairInUse", RpcTarget.AllBufferedViaServer, false);
        }

        
        private void OnPlayerStoodUp()
        {
            _photonView.RPC("ChairInUse", RpcTarget.AllBufferedViaServer, true);
        }

        
    }
}
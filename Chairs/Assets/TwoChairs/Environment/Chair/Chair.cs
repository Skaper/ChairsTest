using Photon.Pun;
using TwoChairs.Interaction;
using UnityEngine;


namespace TwoChairs.Environment.Chair
{
    [RequireComponent(typeof(PhotonView))]
    public class Chair : MonoBehaviour
    {
        public TeleportationSitAnchor SitAnchor;
        public Renderer SitIndicator;
        
        private PhotonView _photonView;

        private void OnEnable()
        {
            SitAnchor.SatDown += OnPlayerSatDown;
            SitAnchor.StoodUp += OnPlayerStoodUp;
        }

        private void OnDisable()
        {
            SitAnchor.SatDown -= OnPlayerSatDown;
            SitAnchor.StoodUp -= OnPlayerStoodUp;
        }

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        [PunRPC]
        public void ChairInUse(bool isUse)
        {
            SitAnchor.enabled = isUse;
            SitIndicator.material.color = isUse ? Color.green : Color.red;
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
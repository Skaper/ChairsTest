using Photon.Pun;
using UnityEngine;

namespace TwoChairs.Network
{
    public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
    {
        private GameObject _spawnedPlayer;
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            _spawnedPlayer = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            PhotonNetwork.Destroy(_spawnedPlayer);
        }
    }
}
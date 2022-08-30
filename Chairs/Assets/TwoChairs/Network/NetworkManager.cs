using Photon.Pun;
using TwoChairs.Network.Settings;
using UnityEngine;
namespace TwoChairs.Network
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private RoomSettings _roomSettings;
        private void Start()
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            PhotonNetwork.JoinOrCreateRoom(_roomSettings.RoomName, _roomSettings.GetRoomOptions(), _roomSettings.RoomTypedLobby);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            Debug.Log("Joined a room");
        }
    }
}
using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace TwoChairs.Network
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {
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
            RoomOptions roomOptions = new RoomOptions()
            {
                MaxPlayers = 6,
                IsVisible = true,
                IsOpen = true
            };

            PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            Debug.Log("Joined a room");
        }
    }
}
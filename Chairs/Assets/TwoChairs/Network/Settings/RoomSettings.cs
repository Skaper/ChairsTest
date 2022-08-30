using Photon.Realtime;
using UnityEngine;

namespace TwoChairs.Network.Settings
{
    [CreateAssetMenu(fileName = "New Room Settings", menuName = "Photon/Room Settings", order = 0)]
    public class RoomSettings : ScriptableObject
    {
        public string RoomName = "Room";
        public byte RoomMaxPlayers = 2;
        public bool RoomIsVisible = true;
        public bool RoomIsOpen = true;
        public TypedLobby RoomTypedLobby = TypedLobby.Default;

        public RoomOptions GetRoomOptions()
        {
            return new RoomOptions()
            {
                MaxPlayers = RoomMaxPlayers,
                IsVisible = RoomIsVisible,
                IsOpen = RoomIsOpen
            };
        }
    }
}
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;

public class PhotonCreate : MonoBehaviourPunCallbacks
{
    public void Create()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Photon not connected");
            return;
        }

        //roomName = roomNameField.text;

        //if (roomName.Length > 0)
        //{
        //    Debug.Log(roomName);
        //    RoomOptions roomOptions = new RoomOptions();
        //    roomOptions.MaxPlayers = 2;
        //    PhotonNetwork.CreateRoom(roomName, roomOptions);
        //    systemText.text = "Connection";
        //}
        //else
        //{
        //    systemText.text = "Write the name!";
        //}
    }
}

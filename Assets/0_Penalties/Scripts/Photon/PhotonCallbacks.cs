using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEditorInternal.VersionControl;

public class PhotonCallbacks : MonoBehaviourPunCallbacks
{
    public override void OnCreatedRoom()
    {
        print("Room is created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Failed to create room " + returnCode + " " + message);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the server");
    
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        print("RoomList: " + roomList.Count);
        foreach (RoomInfo info in roomList)
        {
       //Create list of buttons with roomnames

        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Not connected");
    }

    public override void OnJoinedRoom()
    {
            PhotonNetwork.LoadLevel("level1");
    }

}

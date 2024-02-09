using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MyPhoton : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
    //    PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = "Player" + Random.Range(10, 99);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "0.1";
    }

}

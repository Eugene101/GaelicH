using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonJoin : MonoBehaviour
{
    public void JoinButton()
    {
        PhotonNetwork.JoinRoom("room 1");
    }
}

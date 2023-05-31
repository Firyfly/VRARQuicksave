using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _text;

    public RoomInfo _roomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(_roomInfo.Name);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoom : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TMPro.TextMeshProUGUI _roomName;


    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }


    public void OnClick_CreateRoom()
    {
        //Create room


        //Join or create Room
        if (!PhotonNetwork.IsConnected)
        {
            return;

        }

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        options.BroadcastPropsChangeToAll = true;
        //Other options like TTL for playyers or rooms possible
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);

    }

    public override void OnCreatedRoom()
    {
        _roomsCanvases._CurrentRoomCanvas.Show();
        Debug.Log("Create Room sucessfully");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create Room failed: " + message);

    }

}

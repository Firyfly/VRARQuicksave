using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnectPhoton : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NickName = MasterManager.gameSettings.nickName;

        PhotonNetwork.AutomaticallySyncScene = true;

        Debug.Log("Connecting to Server!");
        PhotonNetwork.GameVersion = MasterManager.gameSettings.gameVersion;
        PhotonNetwork.ConnectUsingSettings();

    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server!");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);

        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
        

    }

    public override void OnDisconnected(DisconnectCause cause)
    {

        Debug.Log("Disconnected From Server because: " + cause);

    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _text;

    public Player _player { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        _player = player;

        SetPlayerText(player);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
       
        if (targetPlayer != null && targetPlayer == _player)
        {
            //SetPlayerText(targetPlayer);
            if (changedProps.ContainsKey("RandomNumber"))
            {
                SetPlayerText(targetPlayer);
            }
        }
    }

    private void SetPlayerText(Player player)
    {
        int result = -1;

        if (player.CustomProperties.ContainsKey("RandomNumber"))
        {
            result = (int)player.CustomProperties["RandomNumber"];
        }

        _text.text = result.ToString() + " , " + player.NickName;
    }

}

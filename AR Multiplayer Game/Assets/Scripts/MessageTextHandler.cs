using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.CrossPlatformInput;

public class MessageTextHandler : MonoBehaviourPunCallbacks
{
    public Text MessageText;
    public GameObject CloseBtn;

    public void RedTextColor()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject p in Players)
        {
            NewSendMessage("ColorRed");
        }
        //MessageText.color = Color.red;
    }

    public void GreenTextColor()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject p in Players)
        {
            NewSendMessage("ColorGreen");
        }
        //MessageText.color = Color.green;
    }

    public void NewSendMessage(string newText)
    {
        Player targetPlayer = null;

        string PlayerName = "";

        for(int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if(!PhotonNetwork.PlayerList[i].IsLocal)
            {
                targetPlayer = PhotonNetwork.PlayerList[i];
            }
            else
            {
                PlayerName = PhotonNetwork.PlayerList[i].NickName;
            }
        }

        if(PlayerName.Length > 0)
        {
            newText = PlayerName + "'s " + newText;
        }

        photonView.RPC("RPCSendMessage", targetPlayer, newText);
    }

    [PunRPC]
    void RPCSendMessage(string newText)
    {
        MessageText = GameObject.FindGameObjectWithTag("MessageText").GetComponent<Text>();

        this.GetComponent<Image>().enabled = true;

        MessageText.enabled = true;

        GetComponent<UITextTypeWriter>().StartWriting(newText);

        CloseBtn.SetActive(true);
    }

    public void closePanel()
    {
        this.GetComponent<Image>().enabled = false;
        MessageText.enabled = false;
        CloseBtn.SetActive(false);
    }
}

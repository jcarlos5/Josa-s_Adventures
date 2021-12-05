using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LevelMultiplayerController : MonoBehaviourPunCallbacks
{
    private static string avatar = "Player";

    public static void SetAvatar(string avi){
        avatar = avi;
    }

    public static string GetAvatar(){
        return avatar;
    }

    public void Start()
    {
        
        PhotonNetwork.Instantiate(avatar, new Vector3(0, 20, 0), Quaternion.identity);
    }
}

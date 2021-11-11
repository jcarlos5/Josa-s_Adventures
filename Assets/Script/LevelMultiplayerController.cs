using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LevelMultiplayerController : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 7, 0), Quaternion.identity);
    }
}

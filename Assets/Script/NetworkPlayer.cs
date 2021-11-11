using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public MonoBehaviour[] codigosQueIgnorar;

    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(!photonView.IsMine)
        {
            foreach(var codigo in codigosQueIgnorar)
            {
                codigo.enabled = false;
            }
        }
    }
}

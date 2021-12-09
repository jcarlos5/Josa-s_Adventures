using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NewPlayerController : MonoBehaviour
{
    private Vector3 portalPosition;
    public bool inAttack;

    void Start()
    {
        portalPosition = GameObject.FindWithTag("Portal").transform.position;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            inAttack = true;
            Invoke("StopAttack", 1f);
        }
        if(Input.GetKeyDown( KeyCode.E ) && (transform.position.x < portalPosition[0] + 3 && transform.position.x > portalPosition[0] - 3) && (transform.position.z < portalPosition[2] + 3 && transform.position.z > portalPosition[2] - 3))
        {
            Debug.Log("Cruzaste el portal");
        }
    }

    private void StopAttack()
    {
        inAttack = false;
    }

    public void ExitGame()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene ("eo");
    }
}

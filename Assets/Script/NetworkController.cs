using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public static NetworkController instancia;
    public Text PlayerName;
    public Text PlayerNameError;
    public Text RoomName;
    public Text RoomNameError;
    public Text LoadingText;
    public Text RoomNameTitle;

    public Button ConnectButton;
    public Button StartButton;

    public GameObject RoomPanel;
    public GameObject ConfigurationPanel;
    public GameObject PlayersList;
    public GameObject PlayerItem;

    void Awake()
    {
        instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        ConnectButton.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        LoadingText.gameObject.SetActive(false);
        ConnectButton.gameObject.SetActive(true);
    }

    public void OnClickConnectButton()
    {
        if(PlayerName.text.Length >= 3)
        {
            PlayerNameError.gameObject.SetActive(false);
            PhotonNetwork.NickName = PlayerName.text;
            if(RoomName.text.Length >= 3)
            {
                RoomNameError.gameObject.SetActive(false);
                PhotonNetwork.JoinOrCreateRoom(RoomName.text, new RoomOptions { MaxPlayers = 10 }, TypedLobby.Default);
            }
            else
            {
                RoomNameError.gameObject.SetActive(true);
            }
        }
        else
        {
            PlayerNameError.gameObject.SetActive(true);
        }
    }

    public override void OnJoinedRoom()
    {
        RoomNameTitle.text = "SALA: " + PhotonNetwork.CurrentRoom.Name;
        ConfigurationPanel.SetActive(false);
        RoomPanel.SetActive(true);
        if(PhotonNetwork.IsMasterClient)
        {
            StartButton.gameObject.SetActive(true);
        }
        ShowPlayersList();
        //PhotonNetwork.Instantiate("Personaje", new Vector3(Random.Range(-13,13), 0, Random.Range(-13, 13)), Quaternion.identity);
    }

    public void ShowPlayersList()
    {
        for (int i = 0; i < PlayersList.transform.childCount; i++)
        {
            Destroy(PlayersList.transform.GetChild(i).gameObject);
        }
        int n = 0;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            GameObject item = Instantiate(PlayerItem, PlayersList.transform);
            item.transform.GetChild(0).GetComponent<Text>().text = player.NickName;
            item.transform.position = item.transform.position - new Vector3(0, 45f*n, 0);
            n++;
        }
    }

    public void OnLeftRoomButtonClick()
    {
        PhotonNetwork.LeaveRoom();
        RoomPanel.gameObject.SetActive(false);
        ConfigurationPanel.gameObject.SetActive(true);
    }

    public void OnStartGameButtonClick()
    {
        PhotonNetwork.LoadLevel("xdPruebita");
    }

    public void OnExitButtonClick()
    {
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene("eo");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        ShowPlayersList();
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        ShowPlayersList();
        if(PhotonNetwork.IsMasterClient)
        {
            StartButton.gameObject.SetActive(true);
        }
    }
}

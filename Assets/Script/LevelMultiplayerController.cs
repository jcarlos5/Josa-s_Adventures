using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LevelMultiplayerController : MonoBehaviourPunCallbacks
{
    public GameObject boximon;
    private List<GameObject> enemies;
    int xPos;
    int zPos;
    int enemyCount;
    private float range = 480.0f;
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
        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Generator());
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        //Sets the position to be somewhere inside a sphere with radius 480
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        //SamplePosition: Finds the nearest point based on the NavMesh within a specified range
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    IEnumerator Generator(){
        for (int i = 0; i < 800; i++)
        {   
            enemies = new List<GameObject>();
            GameObject spawned = PhotonNetwork.Instantiate("vEnemyMultiplayerAI", RandomNavmeshLocation(range), Quaternion.identity) as GameObject ;
            enemies.Add(spawned);
            yield return new WaitForSeconds(0.01f);
        }
        
    }
}

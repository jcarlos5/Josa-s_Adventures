using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGenerator : MonoBehaviour
{
    
    public GameObject boximon;
    private List<GameObject> enemies;
    int xPos;
    int zPos;
    int enemyCount;
    private float range = 500.0f;
    //[Range (-480,480)]

    IEnumerator Generator(){
        for (int i = 0; i < 800; i++)
        {   
            enemies = new List<GameObject>();
            //xPos = Random.Range(-500, 500);
            //zPos = Random.Range(-500, 500);
            GameObject spawned = Instantiate(boximon, RandomNavmeshLocation(range), Quaternion.identity) as GameObject ;
            enemies.Add(spawned);
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine(Generator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        //Debug.Log(randomDirection);
        //randomDirection += transform.position;
        //Debug.Log(randomDirection);
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}

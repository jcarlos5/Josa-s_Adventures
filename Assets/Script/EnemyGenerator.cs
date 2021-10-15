using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject boximon;
    int xPos;
    int zPos;
    int enemyCount;

    IEnumerator Generator(){
        while (enemyCount < 3000) {
            xPos = Random.Range(-500, 500);
            zPos = Random.Range(-500, 500);
            Instantiate(boximon, new Vector3(xPos, 46, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            enemyCount++;
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
}

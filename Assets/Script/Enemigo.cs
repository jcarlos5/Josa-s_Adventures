using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    public float visionRadius;
    public float speed;
    GameObject player;
    Vector3 initialPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
    }

    void Update()
    {
       Vector3 target = initialPosition;

       float dist = Vector3.Distance(player.transform.position, transform.position);
       if (dist < visionRadius) target = player.transform.position;

       float fixedSpeed = speed*Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);       
    }
}
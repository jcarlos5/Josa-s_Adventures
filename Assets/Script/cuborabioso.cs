using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuborabioso : MonoBehaviour
{
    //var target : Transform; 
    //var moveSpeed = 3;
    private var rotationSpeed = 6;


    //var myTransform : Transform;


    void Awake()
    {
        myTransform = transform;
    }


    void Start(){
        target = GameObject.FindWithTag("Player").transform; //target the player

    }


    void Update () {
        //Calcular distancia
        var distancia : float;
        distancia = Vector3.Distance(target.transform.position, transform.position);

        //Si la distancia es menor a 4
        if(distancia<4){
            //Voltear
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
            //Caminar
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            //Lineas de debug que aparecen en la ventana Scene
            Debug.DrawLine (target.transform.position, transform.position, Color.red,  Time.deltaTime, false);
        }
    }
   
}


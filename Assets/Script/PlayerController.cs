using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isImmortal = false;
    private int numPieces = 0;
    private int health = 100;
    private int apples = 0;

    public Text txtPieces, txtBonus, txtApples;
    public int targetPieces = 4;
    public float bonusTime = 30f;

    private void Start()
    {
        UpdatePieces();
        UpdateApples();
    }

    private void Update()
    {
        if (isImmortal){
            bonusTime -= Time.deltaTime;
            UpdateBonusTime();
            if (bonusTime == 0){
                isImmortal = false;
                txtBonus.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag ==  "KeyPiece")
        {
            numPieces++;
            UpdatePieces();
        }
        else if(obj.gameObject.tag ==  "FirstAidKit")
        {
            health += 20;
        }
        else if(obj.gameObject.tag ==  "ImmortalityPocion")
        {
            isImmortal = true;
        }
        else if(obj.gameObject.tag ==  "Apple")
        {
            apples++;
        }
    }

    private void UpdatePieces()
    {
        txtPieces.text = "Piezas de la llave: " + numPieces + " / " + targetPieces;
    }

    private void UpdateBonusTime()
    {
        txtBonus.text = "Bonus time: "+ bonusTime;
    }

    private void UpdateApples()
    {
        txtApples.text = "x "+ apples;
    }

    public void reduceHealth(int damage)
    {
        if (!isImmortal){
            health -= damage;
        }
    }
}

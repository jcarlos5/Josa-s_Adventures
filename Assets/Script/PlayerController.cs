using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isImmortal = false;
    private int numPieces = 0;
    public int health = 100;
    private int apples = 0;

    public Text txtPieces, txtBonus, txtApples;
    public int targetPieces = 4;
    public float bonusTime = 30f;
    private Vector3 portalPosition;

    private void Start()
    {
        UpdatePieces();
        UpdateApples();
        portalPosition = GameObject.FindWithTag("Portal").transform.position;
    }

    private void Update()
    {
        if (isImmortal){
            bonusTime -= Time.deltaTime;
            UpdateBonusTime();
            if (bonusTime <= 0){
                isImmortal = false;
                txtBonus.text = "";
            }
        }
        if(Input.GetKeyDown( KeyCode.E ) && (transform.position.x < portalPosition[0] + 3 && transform.position.x > portalPosition[0] - 3) && (transform.position.z < portalPosition[2] + 3 && transform.position.z > portalPosition[2] - 3))
        {
            if(numPieces == targetPieces)
            {
                Debug.Log("Gracias por jugar :'3");
                SceneManager.LoadScene ("e0");
            }
            else
            {
                Debug.Log("Debes juntar los " + targetPieces + " fragmentos de la llave para atravesar el portal");
            }
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag ==  "KeyPiece")
        {
            numPieces++;
            Destroy(obj.gameObject);
            UpdatePieces();
        }
        else if(obj.gameObject.tag ==  "FirstAidKit")
        {
            if(health<=80)
            {
                health += 20;
            }
            else
            {
                health = 100;
            }
            Destroy(obj.gameObject);
        }
        else if(obj.gameObject.tag ==  "ImmortalityPocion")
        {
            isImmortal = true;
            Destroy(obj.gameObject);
        }
        else if(obj.gameObject.tag ==  "Apple")
        {
            apples++;
            Destroy(obj.gameObject);
            UpdateApples();
        }

        if(Input.GetMouseButtonDown(0) && (obj.gameObject.tag ==  "Enemy"))
        {
            obj.GetComponent<BoximonBehavior>().TakeDamage(10);
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
        txtApples.text = "Apples x "+ apples;
    }

    public void reduceHealth(int damage)
    {
        if (!isImmortal){
            health -= damage;
        }
    }
}

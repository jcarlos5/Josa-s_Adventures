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
    private Slider healthSlider;
    private Animator PlayerAnimator;
    public static bool isBeingAttacked = false;

    public Text txtPieces, txtBonus, txtApples;
    public int targetPieces = 4;
    public float bonusTime = 30f;
    private Vector3 portalPosition;
    public GameObject healthBar;

    public GameObject PlayerSkin;

    void Start()
    {
        UpdatePieces();
        UpdateApples();
        portalPosition = GameObject.FindWithTag("Portal").transform.position;
        PlayerAnimator = PlayerSkin.GetComponent<Animator>();
        healthSlider = healthBar.GetComponent<Slider>();
        UpdateHealth();
    }

    void Update()
    {
        if (isImmortal){
            bonusTime -= Time.deltaTime;
            UpdateBonusTime();
            if (bonusTime <= 0){
                isImmortal = false;
                bonusTime = 30f;
                txtBonus.text = "";
            }
        }
        if(Input.GetKeyDown( KeyCode.E ) && (transform.position.x < portalPosition[0] + 3 && transform.position.x > portalPosition[0] - 3) && (transform.position.z < portalPosition[2] + 3 && transform.position.z > portalPosition[2] - 3))
        {
            if(numPieces == targetPieces)
            {
                resetLevel();
            }
            else
            {
                Debug.Log("Debes juntar los " + targetPieces + " fragmentos de la llave para atravesar el portal");
            }
        }
    }

    void OnTriggerEnter(Collider obj)
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
            UpdateHealth();
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
    }

    void OnTriggerStay(Collider obj)
    {
        if(Input.GetMouseButtonDown(0) && (obj.gameObject.tag ==  "Enemy"))
        {
            PlayerAnimator.SetBool("IsAttacking", true);
            obj.GetComponent<BoximonBehavior>().TakeDamage(100);
            Invoke("StopAttack", 1f);
        }
    }

    private void StopAttack()
    {
        PlayerAnimator.SetBool("IsAttacking", false);
    }

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag ==  "Ball")
        {
            reduceHealth(10);
            Destroy(obj.gameObject);
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

    private void UpdateHealth()
    {
        healthSlider.value = health;
    }

    public void reduceHealth(int damage)
    {
        if (!isImmortal){
            health -= damage;
            isBeingAttacked = true;
            UpdateHealth();
            if(health <= 0)
            {
                resetLevel();
            }
        }
        Invoke("resetBlood", 1f);
    }

    public void resetBlood(){
        isBeingAttacked = false;
    }

    private void resetLevel()
    {
        Debug.Log("Game over.");
        health = 100;
        numPieces = 0;
        apples = 0;
        UpdateApples();
        UpdatePieces();
        UpdateHealth();
        SceneManager.LoadScene("eo");
    }
}

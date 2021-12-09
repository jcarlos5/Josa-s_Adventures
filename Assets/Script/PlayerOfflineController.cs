using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Invector.vCharacterController;
using Invector.vItemManager;

public class PlayerOfflineController : MonoBehaviour
{
    private Vector3 portalPosition;
    public bool isImmortal = false;
    private int numPieces = 0;
    public Text txtPieces, txtBonus, txtMoney;
    public int targetPieces = 4;
    public float bonusTime = 30f;
    private vThirdPersonController invectorController;
    private vItemManager itemManager;
    private int numKeys, numMoney, globalMoney;

    void Start()
    {
        invectorController = gameObject.GetComponent<vThirdPersonController>();
        portalPosition = GameObject.FindWithTag("Portal").transform.position;
        itemManager = gameObject.GetComponent<vItemManager>();
    }

    void Update()
    {
        if (isImmortal){
            invectorController.AddHealth(100);
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
            Debug.Log("Cruzaste el portal");
        }
    }

    private void UpdateBonusTime()
    {
        txtBonus.text = "Bonus time: "+ bonusTime;
    }

    public void SetInmortal()
    {
        isImmortal = true;
    }

    public void UpdateKeysAmount()
    {
        var item = itemManager.items.Find(i => i.id == 13);
        if (item != null)
        {
            numKeys = item.amount;
            txtPieces.text = "Piezas de la llave: " + item.amount + " / " + targetPieces;
        }
    }

    public void UpdateMoneyAmount()
    {
        var item = itemManager.items.Find(i => i.id == 15);
        if (item != null)
        {
            globalMoney -= numMoney;
            numMoney = item.amount;
            globalMoney += numMoney;
            txtMoney.text = "Monedas generales:  " + globalMoney;
        }
    }

    
}

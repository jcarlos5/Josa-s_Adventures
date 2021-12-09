using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Invector.vCharacterController;
using Invector.vItemManager;
using UnityEngine.SceneManagement;

public class PlayerOfflineController : MonoBehaviour
{
    public Invector.vItemManager.ItemReference itemKey;
    private Vector3 portalPosition;
    public bool isImmortal = false;
    public Text txtPieces, txtBonus, txtMoney, txtMessage;
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
        LoadData();

        txtPieces.text = "Piezas de la llave: " + numKeys + " / " + targetPieces;
        txtMoney.text = "Monedas generales:  " + globalMoney;
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
            if(numKeys>=targetPieces)
            {
                txtMessage.text = "Bien hecho.";
                Invoke("limpiartxtMsg", 2f);
                Invoke("IrAInicio", 2.5f);
            }else
            {
                txtMessage.text = "Debes conseguir las " + targetPieces + " piezas de la llave.";
                Invoke("limpiartxtMsg", 2f);
            }
        }
    }

    public void IrAInicio()
    {
        SceneManager.LoadScene("eo");
    }

    public void limpiartxtMsg()
    {
        txtMessage.text = "";
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
            txtPieces.text = "Piezas de la llave: " + numKeys + " / " + targetPieces;
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

    public void Morir_uwu()
    {
        SaveData();
        Invoke("cambiarEscena", 2f);
    }

    public void cambiarEscena()
    {
        SceneManager.LoadScene("EndMenu");
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Money", globalMoney);
        PlayerPrefs.SetInt("Keys", numKeys);
    }

    private void LoadData()
    {
        globalMoney = PlayerPrefs.GetInt("Money", 0);
        numKeys = PlayerPrefs.GetInt("Keys", 0);
    }
}

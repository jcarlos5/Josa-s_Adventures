using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewOportunity : MonoBehaviour
{
    public Text txtMoney;
    private int numKeys, globalMoney;
    public Button btnRevivir;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        txtMoney.text = "Moneda recolectadas: " + globalMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Oportunity(){
        if (globalMoney >= 10){
            globalMoney = globalMoney - 10;
            SaveData();
            cambiarEscena();
        }else{
            btnRevivir.gameObject.SetActive(false);
            txtMoney.text = "Monedas insuficientes";
        }
    }

    public void cambiarEscena()
    {
        SceneManager.LoadScene("e1");
    }

    public void Reset(){
        numKeys= 0;
        SaveData();
        SceneManager.LoadScene("eo");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text txtMoney;

    void Start()
    {
        txtMoney.text = "Monedas: "+PlayerPrefs.GetInt("Money", 0);
    }

    public void Jugar()
    {
        SceneManager.LoadScene ("e1");
    }

    public void MultiJugar(){
        SceneManager.LoadScene ("AvatarMenu");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Saliste del Juego");
    }
}

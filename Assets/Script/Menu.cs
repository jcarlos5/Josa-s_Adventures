using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

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

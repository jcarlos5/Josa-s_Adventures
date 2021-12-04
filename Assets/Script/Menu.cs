using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene ("AvatarMenu");
    }

    public void MultiJugar(){
        SceneManager.LoadScene ("MenuMultiplayer");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Saliste del Juego");
    }
}

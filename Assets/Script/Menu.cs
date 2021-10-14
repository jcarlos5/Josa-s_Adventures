using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Game()
    {
        SceneManager.LoadScene ("e1");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("salio del juego");
    }
}

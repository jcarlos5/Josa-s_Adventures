using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BradySelected(){
        LevelMultiplayerController.SetAvatar("Player");
        SceneManager.LoadScene ("MenuMultiplayer");
    }
    public void JolleenSelected(){
        LevelMultiplayerController.SetAvatar("Jolleen");
        SceneManager.LoadScene ("MenuMultiplayer");
    }
    public void JosaSelected(){
        LevelMultiplayerController.SetAvatar("Player");
        SceneManager.LoadScene ("MenuMultiplayer");
    }


}

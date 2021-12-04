using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseAvatar : MonoBehaviour
{
    public static GameObject avatarSelected;
    public GameObject brady;
    public GameObject josa;
    public GameObject jolleen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BradySelected(){
        avatarSelected = brady;
        SceneManager.LoadScene ("e1");
    }
    public void JolleenSelected(){
        avatarSelected = jolleen;
        SceneManager.LoadScene ("e1");
    }
    public void JosaSelected(){
        avatarSelected = josa;
        SceneManager.LoadScene ("e1");
    }


}

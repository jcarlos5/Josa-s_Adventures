using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private bool isPlayerInRange;
    public TextMeshProUGUI textD;

    [TextArea (2,4)] public string[] parrafos;
    int index = 0;
    public float velParrafo;
    public GameObject botonContinue;
    public GameObject botonQuitar;
    public GameObject panelDialogo;
    public GameObject botonLeer;

    // Start is called before the first frame update
    void Start()
    {
        botonQuitar.SetActive(false);
        botonLeer.SetActive(false);
        panelDialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyUp(KeyCode.L))
        {
            activarBotonLeer();                
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            siguienteParrafo();                
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            botonCerrar();               
        }
    }

    IEnumerator TextDialogo(){
        foreach (char letra in parrafos[index])
        {
            textD.text += letra;
            yield return new WaitForSecondsRealtime(velParrafo);
        }
    }
    public void siguienteParrafo(){
        botonContinue.SetActive(true);
        index++;
        if (index < parrafos.Length -1)
        {            
            textD.text="";
            StartCoroutine(TextDialogo());
        }
        else
        {
            textD.text = "...";
            botonContinue.SetActive(false);
            botonQuitar.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            botonLeer.SetActive(true);         
        }
        else
        {
            botonLeer.SetActive(false);
        }
    }

    public void activarBotonLeer()
    {            
        panelDialogo.SetActive(true);
        botonLeer.SetActive(false);                    
    }
    public void botonCerrar()
    {
        panelDialogo.SetActive(false);
        botonLeer.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{
    public Image bloodEffect;
    public bool isGettingHurt;
    public float r, g, b, a;
    // Start is called before the first frame update
    void Start()
    {
        r = bloodEffect.color.r;
        g = bloodEffect.color.g;
        b = bloodEffect.color.b;
        a = bloodEffect.color.a;
        
    }

    // Update is called once per frame
    void Update()
    {
        isGettingHurt = PlayerController.isBeingAttacked;
        
        if (isGettingHurt){
            a = Mathf.Clamp(a,0,1f);
            a += 0.1f;
            ChangeColor();
        }else{
            a = Mathf.Clamp(a,0,1f);
            a -= 0.08f;
            ChangeColor();
        }
        
    }

    private void ChangeColor(){
        bloodEffect.color = new Color(r,g,b,a);
    }
}

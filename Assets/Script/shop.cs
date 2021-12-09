using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shop : MonoBehaviour
{
    //Serializable: Indica al compilador que todo el contenido de la clase puede conservarse en un archivo
    [System.Serializable] class shopItem{
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
    }

    //Se le dice a Unity que lo serialice y lo muestre en el Editor
    [SerializeField] List<shopItem> ShopItemsList;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;

    // Start is called before the first frame update
    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild (0).gameObject;

        int len = ShopItemsList.Count;

        for (int i = 0; i < len; i++){
            g = Instantiate (ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent <Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent <Text>().text = ShopItemsList[i].Price.ToString();
            g.transform.GetChild(2).GetComponent <Button> ().interactable = !ShopItemsList [i].IsPurchased;
            
        }

        Destroy(ItemTemplate);
        
    }

}

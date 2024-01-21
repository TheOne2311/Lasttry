using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory :MonoBehaviour
{
    [SerializeField] private UIInventoryItem item_Prefabs;
    [SerializeField] private RectTransform Item_Panel;
    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    //Instantiate items in Inventory
    public void InitializeInventory (int inventorysize = 5)
    {
        for (int i = 0; i<inventorysize; i++)
        {
            UIInventoryItem uiitem = Instantiate(item_Prefabs, Vector3.zero, Quaternion.identity);
            uiitem.transform.SetParent(Item_Panel);
            uiitem.transform.localScale = new Vector3 (1,1,1);
            listOfUIItems.Add(uiitem);
        }
    }

    // Toggle the Inventory
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

 
}

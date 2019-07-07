using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;
    public Text itemText;
    public Image itemImage;

    public void SetItem(Item item)
    {
        this.item = item; 
        SetupItemValues();
    }

    void SetupItemValues()
    {

        // Item_Name, the UI element we're in search for. 
        // this.transform.Find("Item_Name").GetComponent<Text>().text = item.ItemName;
        itemText.text = item.ItemName;

        // Grab sprite property of image component
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug); 
    }

    public void OnSelectItemButton()
    {
        // Go through the inventory controeller.
        // Debug.Log("Clicking object inside inventory. Passed.");
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}

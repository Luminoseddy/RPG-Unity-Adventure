using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Reference the inventory panel
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    bool MenuIsActive             { get; set; }
    InventoryUIItem ItemContainer { get; set; }
    Item CurrentSelectedItem      { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        ItemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false); // Hides inventory on play
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            MenuIsActive = !MenuIsActive;// if true then when button pressed false and vise versa.
            inventoryPanel.gameObject.SetActive(MenuIsActive);
        }
    }

    // Update is called once per frame
    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(ItemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }
}

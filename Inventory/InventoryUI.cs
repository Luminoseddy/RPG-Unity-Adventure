using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    // Reference the inventory panel
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;

    bool menuIsActive             { get; set; }
    InventoryUIItem itemContainer { get; set; }
    Item currentSelectedItem      { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandlerController.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false); // Hides inventory on play
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;// if true then when button pressed false and vise versa.
            inventoryPanel.gameObject.SetActive(menuIsActive);
        }
    }

    // Update is called once per frame
    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }
}

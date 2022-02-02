using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject inventoryUIPanel;

    private List<GameObject> slots = new List<GameObject>();

    private void AddUISlot(InventorySlot slotData)
    {
        GameObject newSlot = Instantiate(slotPrefab);

        newSlot.transform.parent = inventoryUIPanel.transform;

        UISlot newSlotData = newSlot.GetComponent<UISlot>();

        newSlotData.inventorySlot = slotData;
        newSlotData.itemIcon = slotData.slotItem.itemIcon;
        newSlotData.itemQuantity.text = slotData.Quantity.ToString();
    }
}

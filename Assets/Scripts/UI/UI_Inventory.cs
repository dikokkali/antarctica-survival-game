using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject inventoryUIPanel;

    [SerializeField] private PlayerInventory _playerInventory; 

    private List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        DrawInventory();
    }

    private void AddUISlot(InventorySlot slotData)
    {
        GameObject newSlot = Instantiate(slotPrefab);

        newSlot.transform.SetParent(inventoryUIPanel.transform);

        UI_Slot newSlotData = newSlot.GetComponent<UI_Slot>();

        newSlotData.inventorySlot = slotData;
        newSlotData.itemIcon.sprite = slotData.slotItem.itemIcon;
        newSlotData.itemQuantity.text = slotData.Quantity.ToString();
    }

    private void DrawInventory()
    {
        List<InventorySlot> playerInventory = _playerInventory.GetInventory();

        if (playerInventory.Count > 0 && playerInventory != null)
        {
            foreach (var slot in playerInventory)
            {
                AddUISlot(slot);
            }
        }
        else
        {
            Debug.Log("Inventory is empty or null.");
        }
    }

}

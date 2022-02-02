using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // TESTING
    public ItemBase item1, item2;
    public GameObject quickInventoryUI;
    // TESTING

    private List<InventorySlot> _inventory = new List<InventorySlot>();

    public List<InventorySlot> quickInventory = new List<InventorySlot>();

    private void Awake()
    {
        // TODO: Testing purposes, remove
        InventorySlot slot1 = new InventorySlot(item1, 10);
        InventorySlot slot2 = new InventorySlot(item2, 10);

        AddToQuickInventory(slot1);
        AddToQuickInventory(slot2);
    }

    #region Inventory Operations

    public void AddToInventory(ItemBase item, int quantity)
    {
        InventorySlot newSlot = new InventorySlot();

        newSlot.slotItem = item;
        newSlot.Quantity = quantity;
    }

    public void RemoveFromInventory()
    {
        // TODO: Determine how clients request a removal (index, slot etc.)
    }

    public void AddToQuickInventory(InventorySlot slot)
    {
        quickInventory.Add(slot);
    }
    #endregion
}

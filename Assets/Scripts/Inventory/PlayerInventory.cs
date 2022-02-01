using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public class InventorySlot
    {
        public ItemBase slotItem;

        public int Quantity { get; set; } // TODO: Use the getter to return ammo count if item is/has ammunition
    }

    private List<InventorySlot> _inventory = new List<InventorySlot>();

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
    #endregion
}

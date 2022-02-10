using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // TESTING
    public ItemBase item1, item2;
    // TESTING

    public GameObject equipMount;

    private List<InventorySlot> _inventory = new List<InventorySlot>();    

    public List<InventorySlot> quickInventory = new List<InventorySlot>();
    private void Awake()
    {
        // TODO: Testing purposes, remove
        InventorySlot slot1 = new InventorySlot(item1, 10);
        InventorySlot slot2 = new InventorySlot(item2, 10);

        AddToInventory(slot1.slotItem, slot1.Quantity);
        AddToInventory(slot2.slotItem, slot1.Quantity);
    }

    #region Access Methods
    public List<InventorySlot> GetInventory()
    {
        return _inventory;
    }
    #endregion

    #region Inventory Operations

    public void AddToInventory(ItemBase item, int quantity)
    {
        InventorySlot newSlot = new InventorySlot();

        newSlot.slotItem = item;
        newSlot.Quantity = quantity;

        _inventory.Add(newSlot);
    }

    public void RemoveFromInventory()
    {
        // TODO: Determine how clients request a removal (index, slot etc.)
    }

    public void EquipItem(ItemBase item)
    {
        GameObject equipPrefab = Instantiate(item.itemPrefab);

        // TODO: Might need to change if weapons are pooled under the mount  
        if (equipMount.transform.childCount > 0)
        {
            Destroy(equipMount.transform.GetChild(0).gameObject);
        }
              
        equipPrefab.transform.position = equipMount.transform.position;
        equipPrefab.transform.rotation = equipMount.transform.rotation;

        equipPrefab.transform.SetParent(equipMount.transform);        
    }
    #endregion
}

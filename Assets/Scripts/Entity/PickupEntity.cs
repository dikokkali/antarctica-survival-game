using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEntity : MonoBehaviour, IWorldPickup, IInteractable
{
    public ItemBase _itemData;

    public void Interact()
    {
        Debug.Log($"Interacting with {_itemData.itemName}");
    }

    public void TakeItem()
    {
        Debug.Log("Taking Item");
    }
}

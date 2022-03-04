using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour, IPointerClickHandler
{
    public GameObject slotPrefab;
    public GameObject inventoryUIPanel;

    public GameObject contextMenuPanel;

    [SerializeField] private PlayerInventory _playerInventory; 

    private List<GameObject> slots = new List<GameObject>();

    private GameObject selectedSlot = null;

    private void Awake()
    {
        DrawInventory();
    }

    private void OnDisable()
    {
        contextMenuPanel.SetActive(false);
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

    #region Inventory Callbacks

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<UI_Slot>() != null)
            {
                contextMenuPanel.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                contextMenuPanel.SetActive(true);

                selectedSlot = eventData.pointerCurrentRaycast.gameObject;
            }
            else
            {                
                contextMenuPanel.SetActive(false);
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<UI_Slot>() != null) return;           
            
            contextMenuPanel.SetActive(false);            
        }
    }

    #region Context Menu Callbacks

    public void OnContextMenuEquipButtonPressed()
    {
        if (selectedSlot != null)
        {
            var equippable = selectedSlot.GetComponentInParent<UI_Slot>().inventorySlot.slotItem;

            _playerInventory.EquipItem(equippable);
        }
    }

    public void OnContextMenuDropButtonPressed()
    {
        Debug.Log("Clicked on drop context");
    }


    #endregion
    #endregion
}

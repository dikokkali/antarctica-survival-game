using UnityEngine;


public class UI_DisplayController : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;

    #region Inventory Methods
    private void ShowInventory()
    {
        inventoryUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HideInventory()
    {
        inventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public bool IsInventoryUIEnabled()
    {
        if (inventoryUI.activeSelf)
        {
            return true;
        }
        else return false;
    }

    public void OnInventoryButtonPressed()
    {
        Debug.Log("Called");
        if (!inventoryUI.activeSelf)
        {
            ShowInventory();
        }
        else
        {
            HideInventory();
        }
    }
    #endregion
}

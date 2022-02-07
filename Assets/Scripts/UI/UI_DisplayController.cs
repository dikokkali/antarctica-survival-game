using UnityEngine;


public class UI_DisplayController : MonoBehaviour
{     
    private InputContextData_FPS _inputContextData;

    [Header("UI Handles")]
    [SerializeField] GameObject inventoryUI;

    [Header("Other Handles")]
    [SerializeField] PlayerInputManager _playerInputManager;

    private void Awake()
    {
        _inputContextData = _playerInputManager.GetComponent<PlayerInputManager>().fpsInputContext;
    }
    private void OnEnable()
    {
        _inputContextData.FPSControls.OpenInventory.performed += ctx => OnInventoryButtonPressed();
        _inputContextData.UIControls.UICloseInventory.performed += ctx => OnInventoryButtonPressed();
    }

    #region Inventory UI Management
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

    #endregion

    #region Callbacks

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

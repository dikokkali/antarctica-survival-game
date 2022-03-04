using UnityEngine.UI;
using UnityEngine;

public class UI_InventoryContextMenu : MonoBehaviour
{
    public Button equipButton;
    public Button dropButton;
    
    private void OnEnable()
    {
        BuildContextMenu();
    }

    private void OnDisable()
    {
        equipButton.gameObject.SetActive(false);
        dropButton.gameObject.SetActive(false);
    }

    private void BuildContextMenu()
    {
        equipButton.gameObject.SetActive(true);
        dropButton.gameObject.SetActive(true);
    }
}

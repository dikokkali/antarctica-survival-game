using UnityEngine;
using UnityEngine.UI;

public abstract class ItemBase : ScriptableObject
{
    protected static int globalItemId = 0;

    public string itemId;
    public string itemName;
    public Sprite itemIcon;
    public GameObject itemPrefab;

    protected abstract void GenerateItemId();  
    
}

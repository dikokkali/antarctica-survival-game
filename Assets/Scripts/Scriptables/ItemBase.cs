using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    protected static int globalItemId = 0;

    public string itemId;
    public string itemName;

    protected abstract void GenerateItemId();
    
}

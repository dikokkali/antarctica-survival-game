using UnityEngine;

[CreateAssetMenu(fileName = "Test", menuName = "Game Data/Test/Test")]
public class TestItem : ItemBase
{
    protected override void GenerateItemId()
    {
        string currentId = ItemBase.globalItemId++.ToString();

        currentId = $"test_{currentId}";

        itemId = currentId;
    }
}

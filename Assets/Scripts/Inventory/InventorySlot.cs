public class InventorySlot
{
    public ItemBase slotItem;

    public int Quantity { get; set; } // TODO: Use the getter to return ammo count if item is/has ammunition

    #region Constructors
    public InventorySlot() { }

    public InventorySlot(ItemBase item, int quantity)
    {
        slotItem = item;
        Quantity = quantity;
    }
    #endregion
}


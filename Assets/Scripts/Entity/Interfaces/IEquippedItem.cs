using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquippedItem
{
    public ItemBase itemData { get; set; }

    public void StartPrimaryTriggerAction();
    public void StopPrimaryTriggerAction();

    public void StartSecondaryTriggerAction();
    public void StopSecondaryTriggerAction();

    public void ReloadAction();
}




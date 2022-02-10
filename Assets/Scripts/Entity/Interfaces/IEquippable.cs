using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquippable<T> where T : ItemBase
{
    public T itemData { get; set; }
}

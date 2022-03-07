using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game Data/Weapons/Weapon")]
public class Weapon : ItemBase
{
    public float baseDamage;
    public float fireRate;
    public float reloadTime;
    public float bulletsPerMagazine;
    public float maxRange;

    public float recoilSpread_Vertical;
    public float recoilSpread_Horizontal;


    public Weapon()
    {
        GenerateItemId();
    }

    protected override void GenerateItemId()
    {
        string currentId = ItemBase.globalItemId++.ToString();

        currentId = $"wep_{currentId}";

        itemId = currentId;
    }
}

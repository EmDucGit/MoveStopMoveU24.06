using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "WeaponShop/WeaponData")]
public class WeaponSO : ScriptableObject
{
    public WeaponShopItem[] weapons;

    public int WeaponsCount
    {
        get { return weapons.Length; }
    }

    public WeaponShopItem GetWeapon (int index)
    {
        return weapons[index];
    }

    public Weapon GetWeaponIG (int index)
    {
        return weapons[index].weapon;
    }

    public void PurWP(int index)
    {
        weapons[index].isPur = true;
        PlayerPrefs.SetInt(weapons[index].name, 1);
    }

    public void ResetWP(int index)
    {
        weapons[index].isPur = false;
    }
}

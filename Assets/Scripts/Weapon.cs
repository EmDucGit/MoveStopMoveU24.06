using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    [SerializeField] public GameObject weaponSkin;
    [SerializeField] public WeaponBullet weaponBullet;
    [SerializeField] string nameWeapon;

    public void SpawnWeaponSkin(Transform weaponSkinPoint)
    {
        Instantiate(weaponSkin, weaponSkinPoint.position, weaponSkinPoint.rotation, weaponSkinPoint);
    }

    public void ThrowWeapon(Transform attackPoint, Transform skin)
    {
        Instantiate(weaponBullet, attackPoint.position, skin.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShopGen : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject shopItemPrefbs;
    [SerializeField] Transform shopContent;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] GameObject wpPlayerMenu;

    private void Start()
    {
        CheckData();
        GenShopItem();
        UpdateCoin();
    }

    void CheckData()
    {
        for(int i = 0; i < weaponSO.WeaponsCount; i++)
        {
            if(PlayerPrefs.GetInt(weaponSO.GetWeapon(i).name) == 0)
            {
                weaponSO.ResetWP(i);
            }
        }
    }

    void GenShopItem()
    {
        for(int i = 0; i < weaponSO.WeaponsCount; i++)
        {
            WeaponShopItem weaponShopItem = weaponSO.GetWeapon(i);
            WeaponShopItemUI uiItem = Instantiate(shopItemPrefbs, shopContent).GetComponent<WeaponShopItemUI>();

            uiItem.gameObject.name = "Item" + i + "-" + weaponShopItem.name;
            uiItem.SetWPIcon(weaponShopItem.icon);
            uiItem.SetWPPrice(weaponShopItem.price);

            if(weaponShopItem.isPur)
            {
                uiItem.SetWPAsPur();
                uiItem.OnWPSelect(i, OnItemSelected);
            } else
            {
                uiItem.SetWPPrice(weaponShopItem.price);
                uiItem.itemBtn.interactable = false;
                uiItem.OnWPPur(i, OnItemPur);
            }
        }
    }

    void OnItemSelected(int index)
    {
        Debug.Log("select" + index);
        PlayerPrefs.SetInt("currEquipWP", index);
    }

    WeaponShopItemUI GetItemUI(int index)
    {
        return shopContent.GetChild(index).GetComponent<WeaponShopItemUI>();
    }

    void OnItemPur(int index)
    {
        WeaponShopItem weaponShopItem = weaponSO.GetWeapon(index);
        WeaponShopItemUI uiItem = GetItemUI(index);
        if(weaponShopItem.price < GameManager.Instance.GetCoins())
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - weaponShopItem.price);
            UpdateCoin();
            weaponSO.PurWP(index);
            uiItem.SetWPAsPur();
        }
    }

    private void UpdateCoin()
    {
        coinText.text = GameManager.Instance.GetCoins().ToString();
    }
}

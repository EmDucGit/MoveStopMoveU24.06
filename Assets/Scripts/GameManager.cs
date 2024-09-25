using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DataWPInit();
        if (PlayerPrefs.HasKey("Coins"))
        {
            return;
        } else
        {
            PlayerPrefs.SetInt("Coins", 10000);
        }

        if (PlayerPrefs.HasKey("currEquipWP"))
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt("currEquipWP", 0);
        }
    }

    public int GetCoins()
    {
        return PlayerPrefs.GetInt("Coins");
    }

    void DataWPInit()
    {
        for(int i = 0; i < weaponSO.WeaponsCount; i++)
        {
            if(PlayerPrefs.HasKey(weaponSO.GetWeapon(i).name))
            {
                Debug.Log("Da co data cua" + weaponSO.GetWeapon(i).name);
            } else
            {
                PlayerPrefs.SetInt(weaponSO.GetWeapon(i).name, 0);
                Debug.Log("Set data" + weaponSO.GetWeapon(i).name + "IsNotPur");
            }
        }
    }

}

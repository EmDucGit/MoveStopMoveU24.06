using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBtn : MonoBehaviour
{
    [SerializeField] Transform model;
    public void OnShopClick()
    {
        model.transform.position = new Vector3(-0.7f, 6, -24);
        model.rotation = Quaternion.Euler(-20, 0, 0);
    }

    public void OnShopClose()
    {
        model.transform.position = new Vector3(-0.7f, 0, -24);
        model.rotation = Quaternion.Euler(0, 0, 0);
    }
}

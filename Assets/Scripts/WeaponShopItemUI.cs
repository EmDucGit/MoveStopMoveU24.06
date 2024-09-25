using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class WeaponShopItemUI : MonoBehaviour
{
    [SerializeField] RawImage icon;
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] Button buyBtn;
    [SerializeField] public Button itemBtn;

    public void SetWPPrice(int wpPrice)
    {
        price.text = wpPrice.ToString();
    }

    public void SetWPIcon(Texture wpIcon)
    {
        icon.texture = wpIcon;
    }

    public void SetWPAsPur()
    {
        buyBtn.gameObject.SetActive(false);
        itemBtn.interactable = true;
    }

    public void OnWPPur(int itemindex, UnityAction<int> onPur)
    {
        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() => onPur.Invoke(itemindex));
    }

    public void OnWPSelect(int itemindex, UnityAction<int> onSelect)
    {
        itemBtn.interactable = true;
        itemBtn.onClick.RemoveAllListeners();
        itemBtn.onClick.AddListener(() => onSelect.Invoke(itemindex));
    }
}

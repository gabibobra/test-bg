using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryItem : MonoBehaviour
{
    public Button sellButton;
    public Button useButton;
    public Image itemImg;

    private Item item;
    private Action onClickCallback;

    public void SetInventoryItem(Item newItem)
    {
        item = newItem;
        itemImg.sprite = item.sprite;
        if (item.handWearable || item.headWearable)
        {
            sellButton.interactable = true;
            useButton.interactable = true;
        }
        else
        {
            sellButton.interactable = true;
            useButton.interactable = false;
        }
    }

    public void SetOnClickCallback(Action callBack)
    {
        onClickCallback = callBack;
    }

    public void OnClickSellItem()
    {
        PlayerController.instance.UpdateItems(item, false);
        onClickCallback?.Invoke();
    }

    public void OnClickUseItem()
    {
        if (item.handWearable || item.headWearable)
        {
            useButton.interactable = false;
            item.isWearingItem = true;
            PlayerController.instance.WearItem(item);
        }
        onClickCallback?.Invoke();
    }

    public int GetPrize()
    {
       return  item.prize;
    }

}

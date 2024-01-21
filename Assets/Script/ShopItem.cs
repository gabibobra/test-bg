using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopItem : MonoBehaviour
{
    public TMP_Text titleTxt;
    public TMP_Text prizeTxt;
    public Button button;
    public Image itemImg;

    private Item item;
    private Action onClickCallback;

    public void SetShopItemTexts(Item newItem)
    {
        item = newItem;
        titleTxt.text = item.title;
        prizeTxt.text = item.prize.ToString();
        itemImg.sprite = item.sprite;
    }    
    
    public void SetOnClickCallback(Action callBack)
    {
        onClickCallback = callBack;
    }

    public void OnClick()
    {
        PlayerController.instance.UpdateItems(item);
        onClickCallback?.Invoke();
    }

    public int GetPrize()
    {
       return  item.prize;
    }

    public void SetButtomEnabled(bool enabled)
    {
        button.interactable =  enabled;
    }
}

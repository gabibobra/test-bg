using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemButtom : MonoBehaviour
{
    public TMP_Text titleTxt;
    public TMP_Text prizeTxt;
    public Button button;
    public Image itemImg;

    private ShopItem item;
    private Action onClickCallback;

    public void SetItemTexts(ShopItem shopItem)
    {
        item = shopItem;
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
        button.animator.SetTrigger("Pressed");
        PlayerController.instance.UpdateItems(item);
        onClickCallback?.Invoke();
    }

    public int GetPrize()
    {
       return  item.prize;
    }

    public void SetButtomEnabled(bool enabled)
    {
       // button.enabled = enabled;
        button.interactable =  enabled;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public PlayerController player;
    public ShopItem[] shopItems;
    private List<ItemButtom> itemButton =  new List<ItemButtom>();
    public GameObject itemButtonPrefab;
    public Transform itemsContainer;

    private void Awake()
    {
    }

    private void Start()
    {
        CreateShopItems();
    }

    public void CreateShopItems()
    {
        for(int i = 0; i < shopItems.Length; i++)
        {
            GameObject newItemButton = Instantiate(itemButtonPrefab, itemsContainer);
            ItemButtom itemButtonComponent = newItemButton.GetComponent<ItemButtom>();
            itemButtonComponent.SetItemTexts(shopItems[i]);
            itemButtonComponent.SetOnClickCallback(UpdateShopItems);
            itemButton.Add(itemButtonComponent);
        }
        UpdateShopItems();
    }

    public void UpdateShopItems()
    {
        for (int i = 0; i < itemButton.Count; i++)
        {
            bool canPurchase = PlayerController.instance.playerCoins > itemButton[i].GetPrize();
            itemButton[i].SetButtomEnabled(canPurchase);
        }
    }

}

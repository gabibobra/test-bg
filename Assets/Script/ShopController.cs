using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public Item[] shopItems;
    public GameObject itemButtonPrefab;
    public GameObject shopUI;
    public Transform itemsContainer;

    private List<ShopItem> itemButtons =  new List<ShopItem>();
    private bool showingUI;

    private void Start()
    {
        EnableUI(false);
        CreateShopItems();
    }

    public void EnableUI(bool enabled)
    {
        shopUI.SetActive(enabled);
        showingUI = enabled;
    }

    public void CreateShopItems()
    {
        for(int i = 0; i < shopItems.Length; i++)
        {
            GameObject newItemButton = Instantiate(itemButtonPrefab, itemsContainer);
            ShopItem shopItemComponent = newItemButton.GetComponent<ShopItem>();
            shopItemComponent.SetShopItemTexts(shopItems[i]);
            shopItemComponent.SetOnClickCallback(UpdateShopItems);
            itemButtons.Add(shopItemComponent);
        }
        UpdateShopItems();
    }

    public void UpdateShopItems()
    {
        for (int i = 0; i < itemButtons.Count; i++)
        {
            bool canPurchase = PlayerController.instance.playerCoins > itemButtons[i].GetPrize();
            itemButtons[i].SetButtomEnabled(canPurchase);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !showingUI)
        {
            EnableUI(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && showingUI)
        {
            EnableUI(false);
        }
    }
}


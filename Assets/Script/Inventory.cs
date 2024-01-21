using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> itemButton = new List<InventoryItem>();
    public GameObject itemButtonPrefab;
    public Transform itemsContainer;

    public void UpdateInventory()
    {
        foreach (Transform child in itemsContainer.transform)
        {
            Destroy(child.gameObject);
        }
        itemButton.Clear();
        for (int i = 0; i < PlayerController.instance.playerItems.Count; i++)
        {
            GameObject newItemButton = Instantiate(itemButtonPrefab, itemsContainer);
            InventoryItem itemButtonComponent = newItemButton.GetComponent<InventoryItem>();
            itemButtonComponent.SetInventoryItem(PlayerController.instance.playerItems[i]);
            //itemButtonComponent.SetOnClickCallback(UpdateShopItems);
            itemButton.Add(itemButtonComponent);
        }
    }


}

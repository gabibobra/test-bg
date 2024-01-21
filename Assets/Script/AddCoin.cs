using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoin : MonoBehaviour
{
    public int coins;
    private bool addCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !addCoins)
        {
            PlayerController.instance.UpdateCoins(coins);
            addCoins = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && addCoins)
        {
            addCoins = false;
        }
    }
}

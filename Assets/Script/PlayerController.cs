using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public int playerCoins;
    private Vector2 moveDirection;
    public TMP_Text coinsTxt;
    public TMP_Text coinsFeedbackTxt;
    public Inventory playerInventory;
    public List<Item> playerItems { get; private set; } = new List<Item>();
    public List<SpriteRenderer> playerWearableSprites = new List<SpriteRenderer>();
    public Animation coinsFeedbackAnim;

    public enum PlayerWearableSlots { Head, Hand };
    public static PlayerController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
        UpdateCoins(40);
        playerInventory.UpdateInventory();
    }

    private void Start()
    {
    }
    void FixedUpdate()
    {
        ProcessInput();
        Move();
    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }


    public void UpdateCoins(int value)
    {
        playerCoins += value;
        coinsTxt.text = playerCoins.ToString();
        if (value > 0)
            coinsFeedbackTxt.text = "+ " + Mathf.Abs(value).ToString();
        else
            coinsFeedbackTxt.text = "- " + Mathf.Abs(value).ToString();
        coinsFeedbackAnim.Play();
    }

    public void UpdateItems(Item item, bool addingItem = true)
    {
        if (addingItem)
        {
            playerItems.Add(item);
            UpdateCoins(-item.prize);

        }
        else
        {
            if (item.isWearingItem)
            {
                if (item.headWearable)
                {
                    playerWearableSprites[0].enabled = false;
                }
                else if (item.handWearable)
                {
                    playerWearableSprites[1].enabled = false;
                }
            }
            playerItems.Remove(item);
            UpdateCoins(item.prize);

        }
        playerInventory.UpdateInventory();
    }

    public void WearItem(Item item)
    {
        if (item.headWearable)
        {
            playerWearableSprites[0].sprite = item.sprite;
            playerWearableSprites[0].enabled = true;
        }
        else if (item.handWearable)
        {
            playerWearableSprites[1].sprite = item.sprite;
            playerWearableSprites[1].enabled = true;
        }
    }

}

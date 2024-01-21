using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public int playerCoins = 30;
    private Vector2 moveDirection;
    public TMP_Text coinsTxt;
    private List<ShopItem> playerItems = new List<ShopItem>();
    public static PlayerController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
        UpdateCoins(30);
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
    }

    public void UpdateItems(ShopItem shopItem)
    {
        playerItems.Add(shopItem);
        UpdateCoins(-shopItem.prize);
    }
}

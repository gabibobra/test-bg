using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseItem", menuName = "Scriptable Objects/New Base Item", order = 1)]
public class Item : ScriptableObject
{
    public string title;
    public int prize;
    public Sprite sprite;
    public bool headWearable;
    public bool handWearable;
    public bool isWearingItem;
}

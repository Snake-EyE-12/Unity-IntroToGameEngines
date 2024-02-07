using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] items;
    public Item currentItem { get; set; }
    private void Start()
    {
        currentItem = items[0];
        currentItem.Equip();
    }

    public void Use()
    {
        currentItem?.Use();
    }

    public void StopUse()
    {
        currentItem?.StopUse();
    }
}

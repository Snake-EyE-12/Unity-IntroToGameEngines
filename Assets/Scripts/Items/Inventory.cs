using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] items;
    private int num = 0;
    public Item currentItem { get; set; }
    private void Start()
    {
        currentItem = items[0];
        currentItem.Equip();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            num++;
            if (num > 1) num = 0;
            currentItem = items[num];
            currentItem.Equip();
        }
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

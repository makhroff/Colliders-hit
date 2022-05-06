using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] items;
    private int currentItem = 0;
    private void Awake()
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] == items[0])
                items[i].SetActive(true);
            else
                items[i].SetActive(false);
        }
    }

    private void Update()
    {
        ChangeItem();
    }
    
    private void ChangeItem()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            items[currentItem].SetActive(false);
            if (items[currentItem] != items[items.Length - 1])
                currentItem++;
            else
                currentItem = 0;

            ActiveCurrentItem();
        }
    }

    private void ActiveCurrentItem()
    {
        items[currentItem].SetActive(true);
    }
}

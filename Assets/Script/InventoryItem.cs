using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] Inventory[] inventories;
    public static InventoryItem instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetItem(Item item)
    {
        Debug.Log(item.type);
        inventories[0].SetItem(item);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    [SerializeField] Item item;

    public void OnClickObj()
    {
        InventoryItem.instance.SetItem(item);
    }
}

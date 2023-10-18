using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    //アイテムの種類を設定
    [SerializeField] Item.Type type;

    public void OnClickObj()
    {
        InventoryItem.instance.SetItem();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    //ƒAƒCƒeƒ€‚Ìí—Ş‚ğİ’è
    [SerializeField] Item.Type type;

    public void OnClickObj()
    {
        InventoryItem.instance.SetItem();
    }
}

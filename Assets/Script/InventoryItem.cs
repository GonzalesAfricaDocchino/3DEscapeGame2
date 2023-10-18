using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public static InventoryItem instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetItem()
    {
        Debug.Log("ƒAƒCƒeƒ€‚ðŠi”[‚µ‚½‚æ");
    }
}

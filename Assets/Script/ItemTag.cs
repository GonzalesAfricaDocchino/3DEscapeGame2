using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    //�A�C�e���̎�ނ�ݒ�
    [SerializeField] Item.Type type;

    public void OnClickObj()
    {
        InventoryItem.instance.SetItem();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public Transform inventoryUI;
    public GameObject inventorySlotPrefab;

    private void Start()
    {
        UpdateInventoryUI();
    }

    //新しいアイテムをインベントリに追加
    public void AddItem(InventoryItem item)
    {
        inventory.Add(item);
        UpdateInventoryUI();
    }

    //既存のアイテムスロットをクリアし、UI要素を再生成
    private void UpdateInventoryUI()
    {
        //アイテムスロットクリア
        foreach (Transform child in inventoryUI)
        {
            Destroy(child.gameObject);
        }

        //インベントリ内アイテムをUIに表示
        foreach (var item in inventory)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryUI);
            Image itemImage = slot.transform.Find("ItemImage").GetComponent<Image>();
            Text itemNameText = slot.transform.Find("ItemName").GetComponent<Text>();

            //アイコン、名前をUIに設定
            //itemImage.sprite = item.icon;
            //itemNameText.text = item.itemName;
        }
    }
}

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

    //�V�����A�C�e�����C���x���g���ɒǉ�
    public void AddItem(InventoryItem item)
    {
        inventory.Add(item);
        UpdateInventoryUI();
    }

    //�����̃A�C�e���X���b�g���N���A���AUI�v�f���Đ���
    private void UpdateInventoryUI()
    {
        //�A�C�e���X���b�g�N���A
        foreach (Transform child in inventoryUI)
        {
            Destroy(child.gameObject);
        }

        //�C���x���g�����A�C�e����UI�ɕ\��
        foreach (var item in inventory)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryUI);
            Image itemImage = slot.transform.Find("ItemImage").GetComponent<Image>();
            Text itemNameText = slot.transform.Find("ItemName").GetComponent<Text>();

            //�A�C�R���A���O��UI�ɐݒ�
            //itemImage.sprite = item.icon;
            //itemNameText.text = item.itemName;
        }
    }
}

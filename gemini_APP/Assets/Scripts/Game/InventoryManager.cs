using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] public GameObject emptyInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    public InventoryItem currentItem;
    // Start is called before the first frame update
    void OnEnable()
    {
        SetText("");
        ClearInventory();
        CreateInventorySlot();
    } 

    public void SetText(string description) {
        itemDescription.text = description;
    }

    void CreateInventorySlot() {
        if (playerInventory) {
            for (int i = 0; i < playerInventory.items.Count ; i++) {
                GameObject temp = Instantiate(emptyInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                newSlot.transform.SetParent(inventoryPanel.transform);
                if (newSlot) {
                    newSlot.SetUp(playerInventory.items[i], this);
                }
            }
        }
    }

    public void SetUpDescription(InventoryItem item) {
        itemDescription.text = "<b>Description: </b>" + item.itemDescription + 
        "<br>" + "<b>Data type: </b>" + item.itemType.typeName;
        currentItem = item;
    }

    public void ClearInventory() {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++) {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }
}

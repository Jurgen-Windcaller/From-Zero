using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform itemSlotsParent;
    [SerializeField] Transform activeItemSlotsParent;
    [SerializeField] GameObject inventoryUI;

    private InventoryManager inventory;
    private ActiveItemManager activeInventory;
    private ItemSlot[] invSlots;
    private ActiveItemSlot[] activeSlots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = InventoryManager.instance;
        inventory.OnItemChangeCallback += UpdateInvUI;

        activeInventory = ActiveItemManager.instance;
        activeInventory.OnActiveItemChangeCallback += UpdateActiveUI;

        invSlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>();
        activeSlots = activeItemSlotsParent.GetComponentsInChildren<ActiveItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryUI.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void UpdateInvUI()
    {
        for (int i = 0; i < invSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                invSlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                invSlots[i].ClearItem();
            }
        }
    }

    public void UpdateActiveUI()
    {
        for (int i = 0; i < activeSlots.Length; i++)
        {
            if (i < activeInventory.items.Count)
            {
                activeSlots[i].AddItem(activeInventory.items[i]);
            }
            else
            {
                activeSlots[i].ClearItem();
            }
        }
    }

    public void SwitchInventoryState()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}

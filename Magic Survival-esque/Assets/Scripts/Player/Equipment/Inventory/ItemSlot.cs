using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;

    [SerializeField] ItemObj item;

    public void AddItem(ItemObj nItem)
    {
        item = nItem;

        icon.sprite = item.data.icon;
        icon.enabled = true;
    }

    public void ClearItem()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void ReplaceItem(ItemObj nItem)
    {
        if (item != null)
        {
            item = nItem;
        }
        else
        {
            Debug.LogWarning("You are trying to replace an item to an empty slot. Do you want to use AddItem()?");
        }
    }

    public void ActivateItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}

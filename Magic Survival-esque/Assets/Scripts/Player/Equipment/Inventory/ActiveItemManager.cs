using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItemManager : MonoBehaviour
{
    #region Singleton
    public static ActiveItemManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public delegate void OnActiveItemChange();
    public OnActiveItemChange OnActiveItemChangeCallback;

    public delegate void OnActiveArmourChange(ItemObj newItem, ItemObj oldItem);
    public OnActiveArmourChange OnActiveArmourChangeCallback;

    public List<ItemObj> items = new List<ItemObj>();

    [SerializeField] int maxInv = 4;

    public bool AddItem(ItemObj item)
    {
        InventoryManager.instance.RemoveItem(item);

        if (items.Count >= maxInv)
        {
            Debug.Log("Not enough space in inventory");

            return false;
        }

        items.Add(item);

        if (OnActiveItemChangeCallback != null)
        {
            OnActiveItemChangeCallback.Invoke();
        }

        if(item.type == ItemType.armour)
        {
            if (OnActiveArmourChangeCallback != null)
            {
                OnActiveArmourChangeCallback.Invoke(item, null);
            }
        }

        return true;
    }

    public void RemoveItem(ItemObj item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            InventoryManager.instance.AddItem(item);
        }
        else
        {
            Debug.LogWarning("Item being removed is not in inventory list");
            return;
        }

        if (OnActiveItemChangeCallback != null)
        {
            OnActiveItemChangeCallback.Invoke();
        }

        if (item.type == ItemType.armour)
        {
            if (OnActiveArmourChangeCallback != null)
            {
                OnActiveArmourChangeCallback.Invoke(null, item); 
            }
        }
    }
}

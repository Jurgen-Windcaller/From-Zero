using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found.");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange OnItemChangeCallback;

    public List<ItemObj> items = new List<ItemObj>();

    [SerializeField] int maxInv = 12;

    public bool AddItem(ItemObj item)
    {
        if (items.Count >= maxInv)
        {
            Debug.Log("Not enough space in inventory");

            return false;
        }

        items.Add(item);

        if (OnItemChangeCallback != null)
        {
            OnItemChangeCallback.Invoke();
        }

        return true;
    }

    public void RemoveItem(ItemObj item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
        else
        {
            Debug.LogWarning("Item being removed is not in inventory list");
        }

        if (OnItemChangeCallback != null)
        {
            OnItemChangeCallback.Invoke();
        }
    }

}

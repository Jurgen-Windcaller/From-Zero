using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : Interactable
{
    [SerializeField] ItemObj item;

    public override void OnInteract()
    {
        base.OnInteract();

        PickUp();
    }

    private void PickUp()
    {
        bool ableToPickup = InventoryManager.instance.AddItem(item);

        if (ableToPickup)
        {
            Debug.Log("Picking up " + item.data.name);

            Destroy(gameObject);
        }
    }
}

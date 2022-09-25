using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        ActiveItemManager.instance.OnActiveArmourChangeCallback += OnItemChange;

        SetVitality(vitality.BaseValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnItemChange(ItemObj newItem, ItemObj oldItem)
    {
        if (newItem != null)
        {
            fortitude.AddModifier(newItem.data.GetModifier());
        }
        
        if (oldItem != null)
        {
            fortitude.RemoveModifier(oldItem.data.GetModifier());
        }
    }
}

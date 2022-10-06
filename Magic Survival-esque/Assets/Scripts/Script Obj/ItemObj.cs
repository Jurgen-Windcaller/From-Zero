using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
public class ItemObj : ScriptableObject
{
    [SerializeField] public ItemType type;
    [SerializeField] public Sprite icon = null;
    [SerializeReference] public ItemData data;

    public void Use()
    {
        ActiveItemManager.instance.AddItem(this);
    }

    #region Data Classes
    [System.Serializable]
    public class ItemData
    {
        [SerializeField] public string name;
        [SerializeField] public string description;

        public virtual Modifier GetModifier()
        {
            // May be overwritten
            return null;
        }
    }

    [System.Serializable]
    public class ScrollData : ItemData
    {
        [SerializeField] public Spell spell;
    }

    [System.Serializable]
    public class ArmourData : ItemData
    {
        [SerializeField] public Modifier armourMod;

        public override Modifier GetModifier()
        {
            return armourMod;
        }
    }

    [System.Serializable]
    public class EffectData : ItemData
    {
        [SerializeField] public string effectDesc;
    }
    #endregion
}

public enum ItemType
{
    scroll,
    armour,
    effect,
};
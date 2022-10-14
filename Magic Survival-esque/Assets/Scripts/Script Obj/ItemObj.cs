using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
public class ItemObj : ScriptableObject
{
    public ItemType type;
    public Sprite icon = null;

    [SerializeReference] public ItemData data;

    public void Use()
    {
        ActiveItemManager.instance.AddItem(this);
    }

    #region Data Classes
    [System.Serializable]
    public class ItemData
    {
        public string name;
        public string description;

        public virtual Modifier GetModifier()
        {
            // May be overwritten
            return null;
        }

        public virtual Spell GetSpell()
        {
            return null;
        }
    }

    [System.Serializable]
    public class ScrollData : ItemData
    {
        public Spell spell;

        public override Spell GetSpell()
        {
            return spell;
        }
    }

    [System.Serializable]
    public class ArmourData : ItemData
    {
        public Modifier armourMod;

        public override Modifier GetModifier()
        {
            return armourMod;
        }
    }

    [System.Serializable]
    public class EffectData : ItemData
    {
        public string effectDesc;
    }
    #endregion
}

public enum ItemType
{
    scroll,
    armour,
    effect,
};
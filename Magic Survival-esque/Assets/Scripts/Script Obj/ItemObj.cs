using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
public class ItemObj : ScriptableObject
{
    // Changes the editor based on the type of the item
    private void OnValidate()
    {
        switch (type)
        {
            case ItemType.armour:
                if (data != null && data.GetType() != typeof(ArmourData))
                {
                    data = new ArmourData();
                }

                break;

            case ItemType.scroll:
                if (data != null && data.GetType() != typeof(ScrollData))
                {
                    data = new ScrollData();
                }

                break;

            case ItemType.effect:
                if (data != null && data.GetType() != typeof(EffectData))
                {
                    data = new EffectData();
                }

                break;
        }
    }

    #region Data Classes
    [System.Serializable]
    public class ItemData
    {
        [SerializeField] public string name;
        [SerializeField] public string description;
        [SerializeField] public Sprite icon = null;

        public virtual Modifier GetModifier()
        {
            // May be overwritten
            return null;
        }
    }

    [System.Serializable]
    public class ScrollData : ItemData
    {
        [SerializeField] public DamageType damageType;
        [SerializeField] public float damage;
        [SerializeField] public float cooldown;

        public override Modifier GetModifier()
        {
            return null;
        }
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

        public override Modifier GetModifier()
        {
            return null;
        }
    }
    #endregion

    public ItemType type;
    [SerializeReference] public ItemData data;

    public void Use()
    {
        ActiveItemManager.instance.AddItem(this);
    }
}

public enum ItemType
{
    scroll,
    armour,
    effect,
};

public enum DamageType
{
    flame,
    frost,
    electric,
    earth,
    necro,
    divine,
    hydro,
};
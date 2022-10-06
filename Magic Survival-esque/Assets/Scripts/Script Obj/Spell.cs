using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Inventory/Spell", order = 2)]
public class Spell : ScriptableObject
{
    [SerializeField] public SpellType type;
    [SerializeReference] public SpellData data;

    #region Data Classes
    [System.Serializable]
    public class SpellData
    {
        [SerializeField] public string name;
        [SerializeField] public float cooldown;
    }

    [System.Serializable]
    public class NonDamagingData : SpellData
    {
        [SerializeField] public NonDamagingSpellEffect effect;
    }

    [System.Serializable]
    public class DamagingData : SpellData
    {
        [SerializeField] public DamageType damageType;
        [SerializeField] public DamagingSpellEffect effect;

        [SerializeField] public int damage;
    }
    #endregion
}

#region Enums
public enum SpellType
{
    damaging,
    nonDamaging,
}

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

public enum DamagingSpellEffect
{
    projectile,
    AOE,
}

public enum NonDamagingSpellEffect
{
    healing,
    debuff,
    buff,
    movement,
}
#endregion
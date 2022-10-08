using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Inventory/Spell", order = 2)]
public class Spell : ScriptableObject
{
    public SpellType type;

    [SerializeReference] public SpellData data;
    [SerializeReference] private Effect effect;

    #region Data Classes
    [Serializable]
    public class SpellData
    {
        public string name;
        public float cooldown;

        public Sprite spellFX;
    }

    [Serializable]
    public class NonDamagingData : SpellData
    {
        public int eAmount;

        public ENonDamagingSpellEffect effect;
    }

    [Serializable]
    public class DamagingData : SpellData
    {
        public int damage;

        public DamageType damageType;
        public EDamagingSpellEffect effect;
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
public enum EDamagingSpellEffect
{
    projectile,
    AOE,
}

public enum ENonDamagingSpellEffect
{
    healing,
    debuff,
    buff,
    movement,
}
#endregion
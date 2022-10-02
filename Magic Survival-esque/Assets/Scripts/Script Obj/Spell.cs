using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Inventory/Spell", order = 2)]
public class Spell : ScriptableObject
{
    private void OnValidate()
    {
        switch (type)
        {
            case SpellType.damaging:
                if(data != null && data.GetType() != typeof(DamagingData))
                {
                    data = new DamagingData();
                }
                
                break;

            case SpellType.nonDamaging:
                if(data != null && data.GetType() != typeof(NonDamagingData))
                {
                    data = new NonDamagingData();
                }

                break;
        }
    }

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
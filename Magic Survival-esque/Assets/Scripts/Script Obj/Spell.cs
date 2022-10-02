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

    [SerializeField] public float cooldown;

    #region Data Classes
    [System.Serializable]
    public class SpellData
    {

    }

    [System.Serializable]
    public class NonDamagingData : SpellData
    {

    }

    [System.Serializable]
    public class DamagingData : SpellData
    {

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
    healing,
};

public enum DamagingSpellEffect
{
    projectile,
    AOE,
}

public enum NonDamagingSpellEffect
{
    AOE,
    debuff,
    buff,
    movement,
}
#endregion
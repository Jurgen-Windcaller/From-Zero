using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Inventory/Spell", order = 2)]
public class Spell : ScriptableObject
{
    public string spellName;
    public float cooldown;
    public float effectAmount;

    public Sprite FX;
    public SpellType type;
    public SpellEffect effectType;

    public ISpellEffect effect = new ProjectileEffect();
    private Dictionary<string, ISpellEffect> spellEffectsDict = new Dictionary<string, ISpellEffect>();

    public void Cast()
    {
        effect.EmpartEffect(FX);
    }

    private void OnValidate()
    {
        /*foreach(KeyValuePair<string, ISpellEffect> elem in spellEffectsDict)
        {
            if(elem.Key == effectType.ToString())
            {
                effect = elem.Value;
                break;
            }
        }*/
    }
}

#region Enums
public enum SpellType
{
    flame,
    frost,
    electric,
    earth,
    necro,
    divine,
    hydro,
};

public enum SpellEffect
{
    projectile,
    AOE,
    healing,
    debuff,
    buff,
    movement,
};
#endregion
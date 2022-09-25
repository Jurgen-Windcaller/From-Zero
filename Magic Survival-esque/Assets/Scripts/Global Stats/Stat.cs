using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] int baseVal;
    
    private List<Modifier> modifiers = new List<Modifier>();

    private bool isDirty = false;
    private int finalVal;

    public int BaseValue { get { return baseVal; } }
    public int FinalValue 
    {
        get 
        {
            if (isDirty)
            {
                isDirty = false;
                finalVal = CalculateFinalValue();

                return finalVal;
            }

            return baseVal;
        } 
    }

    public void AddModifier(Modifier mod)
    {
        if (mod.Value != 0)
        {
            modifiers.Add(mod);
            modifiers.Sort(CompareModOrder);

            isDirty = true;
        }
    }

    public void RemoveModifier(Modifier mod)
    {
        if (mod.Value != 0)
        {
            modifiers.Remove(mod);

            isDirty = true;
        }
    }

    private int CalculateFinalValue()
    {
        float finalValue = baseVal;

        for (int i = 0; i < modifiers.Count; i++)
        {
            Modifier mod = modifiers[i];

            if (mod.Type == ModType.flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == ModType.percentage)
            {
                finalValue *= 1 + mod.Value;
            }
        }
        
        return Mathf.RoundToInt(finalValue);
    }

    private int CompareModOrder(Modifier a, Modifier b)
    {
        if (a.Order < b.Order)
        {
            return -1;
        }
        else if (a.Order > b.Order)
        {
            return 1;
        }
            
        return 0;
    }
}

[Serializable]
public class Modifier
{
    [SerializeField] float value;
    [SerializeField] ModType type;

    public float Value { get { return value; } }
    public int Order { get { return (int)type; } }
    public ModType Type { get { return type; } }
}

public enum ModType 
{
    flat,
    percentage,
}

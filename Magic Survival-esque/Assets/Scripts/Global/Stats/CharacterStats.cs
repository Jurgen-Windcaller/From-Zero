using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    /* 
        Vitality = health
        Animosity = damage
        Fortitude = defence
        Endurance = stamina
    */

    public Stat vitality;
    public Stat animosity;
    public Stat fortitude;
    public Stat endurance;

    public int curVitality { get; private set; }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player is at " + curVitality + " health");

        damage -= fortitude.FinalValue;
        damage = Mathf.Clamp(damage, 1, int.MaxValue);

        curVitality -= damage;

        Debug.Log(transform.name + " took " + damage + " amount of damage, and now has " + curVitality + " health");

        if(curVitality <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // die differently.

        Debug.Log(transform.name + " died");
    }

    public void SetVitality(int newVitality)
    {
        curVitality = newVitality;
    }
}

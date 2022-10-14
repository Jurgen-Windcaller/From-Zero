using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    public Spell spell;
    [SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInstantiate(ItemObj newSpell)
    {
        spell = newSpell.data.GetSpell();

        if(image != null)
        {
            image.sprite = newSpell.icon;
            image.enabled = true;
        }
    }

    public void OnPress()
    {
        spell.Cast();
    }
}

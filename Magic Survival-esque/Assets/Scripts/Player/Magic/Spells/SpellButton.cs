using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    public ItemObj spell;
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
        spell = newSpell;

        if(image != null)
        {
            image.sprite = spell.icon;
            image.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    public ItemObj spellObj;

    [SerializeField] Image image;
    [SerializeField] GameObject buttonUI;

    private GameObject invUI;
    private Spell spell;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        invUI = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        if (invUI.activeSelf && isActive)
        {
            buttonUI.SetActive(false);
            isActive = false;
        }
        else if (!invUI.activeSelf && !isActive)
        {
            buttonUI.SetActive(true);
            isActive = true;
        }
    }

    public void OnInstantiate(ItemObj newSpell)
    {
        spellObj = newSpell;
        spell = newSpell.data.GetSpell();

        if(image != null)
        {
            image.sprite = spellObj.icon;
            image.enabled = true;
        }
    }

    public void OnPress()
    {
        spell.Cast();
    }
}

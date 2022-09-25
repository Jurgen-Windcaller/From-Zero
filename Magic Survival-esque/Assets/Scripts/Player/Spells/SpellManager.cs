using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject spellButtonFab;
    [SerializeField] GameObject transformsParent;

    private List<ItemObj> spells = new List<ItemObj>();
    private ActiveItemManager inventory;
    private Transform[] spellButtonTransforms;

    // Start is called before the first frame update
    void Start()
    {
        spellButtonTransforms = transformsParent.GetComponentsInChildren<Transform>();
        inventory = ActiveItemManager.instance;

        inventory.OnActiveItemChangeCallback += CheckForSpells;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckForSpells()
    {
        for (int i = 0; i < spellButtonTransforms.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                if (inventory.items[i].type == ItemType.scroll && !spells.Contains(inventory.items[i]))
                {
                    spells.Add(inventory.items[i]);
                }
            }

            if(i < spells.Count)
            {
                if (!inventory.items.Contains(spells[i]))
                {
                    spells.Remove(spells[i]);
                }
            }
        }
    }

    private void CreateButtons(ItemObj obj)
    {
        
    }
}

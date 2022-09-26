using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject spellButtonFab;
    [SerializeField] GameObject transformsParent;
    [SerializeField] GameObject canvas;

    public List<ItemObj> spells = new List<ItemObj>();
    private ActiveItemManager inventory;
    private Transform[] spellButtonTransforms;

    // Start is called before the first frame update
    void Start()
    {
        spellButtonTransforms = transformsParent.GetComponentsInChildren<Transform>();
        spellButtonTransforms = spellButtonTransforms.Skip(1).ToArray();

        inventory = ActiveItemManager.instance;

        inventory.OnActiveItemChangeCallback += AddSpells;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddSpells()
    {
        for (int i = 0; i < spellButtonTransforms.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                if (inventory.items[i].type == ItemType.scroll && !spells.Contains(inventory.items[i]))
                {
                    spells.Add(inventory.items[i]);
                    CreateButtons(inventory.items[i], i);
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

    private void CreateButtons(ItemObj item, int iterator)
    {
        GameObject curButton = Instantiate(spellButtonFab, spellButtonTransforms[iterator].position, spellButtonTransforms[iterator].rotation, canvas.transform);

        curButton.GetComponent<SpellButton>().OnInstantiate(item);
    }
}

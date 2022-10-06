using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemObj))]
public class ItemObjectEditor : Editor
{
    SerializedProperty type, data;

    public void OnEnable()
    {
        data = serializedObject.FindProperty("data");
        type = serializedObject.FindProperty("type");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(type);

        ItemType _type = (ItemType)type.intValue;

        if (EditorGUI.EndChangeCheck())
        {
            data.managedReferenceValue = CreateItemData(_type);
        }

        DrawPropertiesExcluding(serializedObject, new string[] {"type", "m_Script"});
        serializedObject.ApplyModifiedProperties();
    }

    private ItemObj.ItemData CreateItemData(ItemType fType)
    {
        switch (fType)
        {
            default:
            case ItemType.scroll:
                return new ItemObj.ScrollData();

            case ItemType.armour:
                return new ItemObj.ArmourData();

            case ItemType.effect:
                return new ItemObj.EffectData();
        }
    }
}

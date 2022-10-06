using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spell))]
public class SpellObjectEditor : Editor
{
    SerializedProperty type, data;

    public void OnEnable()
    {
        type = serializedObject.FindProperty("type");
        data = serializedObject.FindProperty("data");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(type);

        SpellType _type = (SpellType)type.intValue;

        if (EditorGUI.EndChangeCheck())
        {
            data.managedReferenceValue = CreateItemData(_type);
        }

        DrawPropertiesExcluding(serializedObject, new string[] { "type", "m_Script" });
        serializedObject.ApplyModifiedProperties();
    }

    private Spell.SpellData CreateItemData(SpellType fType)
    {
        switch (fType)
        {
            default:
            case SpellType.damaging:
                return new Spell.DamagingData();

            case SpellType.nonDamaging:
                return new Spell.NonDamagingData();
        }
    }
}

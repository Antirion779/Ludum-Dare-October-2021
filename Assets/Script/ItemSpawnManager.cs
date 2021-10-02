using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemSpawn))]
public class ItemSpawnManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ItemSpawn myScript = (ItemSpawn)target;
        if (GUILayout.Button("Spawn a Baby"))
        {
            myScript.SpawnAnItem();
        }
    }
}

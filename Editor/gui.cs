using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TreeSpawner))]

public class gui : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Bu Component Haritaya Ağaç Eker");
        EditorGUILayout.HelpBox("Bu bir ağaç yerleştirme eklentisi!", MessageType.Info);
        DrawDefaultInspector();

        TreeSpawner spawner = (TreeSpawner)target;

        
        if (GUILayout.Button("Agacları Kaldır"))
        {
            spawner.RemoveInList();
        }
    }
   

    private void OnSceneGUI()
    {
        Vector3 mousePosition = Event.current.mousePosition;
        Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
        RaycastHit hit;
        mousePosition = ray.origin;
        
        TreeSpawner t = (TreeSpawner)target;
        //Handles.DrawLine(t.obj.transform.position + Vector3.up, mousePosition);
        
        TreeSpawner spawner = (TreeSpawner)target;
        Handles.color = spawner.discColor;
        Physics.Raycast(ray, out hit);
        Handles.DrawSolidDisc(hit.point, new Vector3(0, .3f, 0), spawner.DiscRange);

        

        //Mouse Click
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            if (Physics.Raycast(ray, out hit))
            {

                GameObject g = Instantiate(spawner.obj, new Vector3(hit.point.x, hit.point.y - 3f, hit.point.z), spawner.obj.transform.rotation);
                Handles.color = Color.red;
                Handles.DrawSolidDisc(g.transform.position, new Vector3(0, 1, 0), 2f);
                spawner.ListAdd(g);
            }
          
        }
        if(Event.current.type == EventType.MouseMove && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.C)
        {
            if (Physics.Raycast(ray, out hit))
            {

                GameObject g = Instantiate(spawner.obj, new Vector3(hit.point.x, hit.point.y - 3f, hit.point.z), spawner.obj.transform.rotation);
                Handles.color = Color.red;
                Handles.DrawWireDisc(g.transform.position, new Vector3(0, 1, 0), 2f);
                spawner.ListAdd(g);
            }
        }
    }
}

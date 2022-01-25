using UnityEngine;
using System.Collections;
//using Cinemachine;
using UnityEditor;

[ExecuteInEditMode]
public class PlayerTool : Editor
{
    bool activo = false;
    private static Vector3 posicion;

    [MenuItem("Tools/Player from here #P")]
    
    public static void Init()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }


    static void OnSceneGUI(SceneView sceneview)
    {
        Handles.BeginGUI();
        if (Event.current.button == 1)
        {
            if (Event.current.type == EventType.MouseDown)
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("PlayerFromHere"), false, Callback, 1);
                menu.ShowAsContext();
                Debug.Log("activado");
                
                    Debug.Log("activo");
                    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        // do stuff
                        Debug.Log(hit.collider.name);
                    posicion = hit.point;
                    }
                
            }
        }
        Handles.EndGUI();
    }

    static void Callback(object obj)
    {
        // Do something
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = posicion + new Vector3(0,player.GetComponent<Collider>().bounds.size.y/2,0);

       // EditorApplication.EnterPlaymode();
    }
}
    


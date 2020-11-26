using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Constructor))]
public class VisualizaConstructor : Editor
{
    //Modificar como pinta el inspector
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Constructor Mitarget = (Constructor)target;
        
        if(GUILayout.Button("Crea con Imagen"))
        {
            Mitarget.CreaConImagen();
        }
        if (GUILayout.Button("Destruye Ladrillos"))
        {
            Mitarget.DestruyeLadrillos();
        }
    }

}

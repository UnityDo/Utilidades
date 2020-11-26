using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConstructorLadrillos))]
public class VisualizaConstructor : Editor
{
    //Modificar como pinta el inspector
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ConstructorLadrillos Mitarget = (ConstructorLadrillos)target;
        
        if(GUILayout.Button("Crea con Imagen"))
        {
            Mitarget.CreaLadrillosImagen();
        }
        if (GUILayout.Button("Destruye Ladrillos"))
        {
            Mitarget.DestruyeLadrillos();
        }
    }

}

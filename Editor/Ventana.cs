using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ventana : EditorWindow
{
    string nombre = "";
    float fuerza = 0f;
    Color color;
    int elementos;
    GameObject objetoPrefab;
    [MenuItem("Window/Mi ventana")]
    static void Init()
    {
        Ventana ventana = (Ventana)EditorWindow.GetWindow(typeof(Ventana));
        ventana.Show();
    }
    private void OnGUI()
    {
        nombre= EditorGUILayout.TextField("Nombre boton", nombre);
        elementos = EditorGUILayout.IntField("Numero de elemetos", elementos);
        fuerza = EditorGUILayout.Slider("Fuerza", fuerza, -3, 3);
        color = EditorGUILayout.ColorField("Color", color);
        objetoPrefab=(GameObject) EditorGUILayout.ObjectField(objetoPrefab, typeof(GameObject), true, GUILayout.Width(200));
       if ( GUILayout.Button("Crea cosas"))
        {
            Debug.Log(nombre);
            for (int i = 0; i < elementos; i++)
            {
                PrefabUtility.InstantiatePrefab(objetoPrefab);
            }
            //Instantiate(objetoPrefab);
      
        }
    }
}

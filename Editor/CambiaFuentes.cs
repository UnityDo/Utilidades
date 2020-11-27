using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class CambiaFuentes : EditorWindow
{
    TMP_FontAsset fuente;
    [MenuItem("Window/Cambia Fuentes")]
    static void Init()
    {
        CambiaFuentes ventana = (CambiaFuentes)EditorWindow.GetWindow(typeof(CambiaFuentes));
        ventana.Show();
    }
    private void OnGUI()
    {

        fuente = (TMP_FontAsset)EditorGUILayout.ObjectField(fuente, typeof(TMP_FontAsset), true, GUILayout.Width(200));
        if (GUILayout.Button("Cambia Fuentes"))
        {
            TextMeshProUGUI[] Textos = GameObject.FindObjectsOfType<TextMeshProUGUI>();

            //Cambiar todas las fuentes
            foreach(TextMeshProUGUI t in Textos)
            {
                t.font = fuente;
                t.UpdateFontAsset();
            }

        }
    }
}

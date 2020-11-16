using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Creacion : Editor
{
    //Se pueden meter atajos de teclado como : % (ctrl on Windows), # (shift), & (alt). 
    [MenuItem("Utilidades/Crea %G")]
    static void CreaGameObject()
    {
        GameObject boton = new GameObject("Boton");
        //Necesita un componte image
       Image imagenBoton= boton.AddComponent<Image>();
        boton.AddComponent<Button>();
        //Crear una caja de texto
        //Cargar una imagen
        Sprite miSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Baraja/bastos_01.png", typeof(Sprite));
        imagenBoton.sprite = miSprite;
        boton.GetComponent<Button>().image = imagenBoton;
        //Creo un nuevo objeto
        GameObject texto = new GameObject("texto");
        //Le meto el component TMPro
        TMPro.TextMeshProUGUI cajatexto= texto.AddComponent<TMPro.TextMeshProUGUI>();
       // texto.GetComponent<TMPro.TextMeshProUGUI>().text = "Play";
        cajatexto.text = "Play";
        //Lo emparento con el boton
        //quien es mi padre? mi padre es boton
        texto.transform.parent = boton.transform;
        //Colocar el objeto donde este seleccionado
        GameObjectUtility.SetParentAndAlign(boton, Selection.activeGameObject);
        //Registrar para poder deshacer
        Undo.RegisterCompleteObjectUndo(boton, "Borra" + boton.name);

    }
    [MenuItem("GameObject/UI/MiBoton")]
    static void CreaBoton()
    {
        GameObject boton = new GameObject("Boton");
        //Necesita un componte image
        Image imagenBoton = boton.AddComponent<Image>();
        boton.AddComponent<Button>();
        //Crear una caja de texto
        //Cargar una imagen
        Sprite miSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Baraja/bastos_01.png", typeof(Sprite));
        imagenBoton.sprite = miSprite;
        boton.GetComponent<Button>().image = imagenBoton;
        //Creo un nuevo objeto
        GameObject texto = new GameObject("texto");
        //Le meto el component TMPro
        TMPro.TextMeshProUGUI cajatexto = texto.AddComponent<TMPro.TextMeshProUGUI>();
        // texto.GetComponent<TMPro.TextMeshProUGUI>().text = "Play";
        cajatexto.text = "Play";
        //Lo emparento con el boton
        //quien es mi padre? mi padre es boton
        texto.transform.parent = boton.transform;
        //Colocar el objeto donde este seleccionado
        GameObjectUtility.SetParentAndAlign(boton, Selection.activeGameObject);

    }

    [MenuItem("Utilidades/Mueve")]
    static void MueveSeleccionado()
    {
        Selection.activeTransform.parent = null;
        Selection.activeTransform.position = new Vector3(0, 0, 0);
    }
    //Crear prefab
    [MenuItem("Utilidades/Crear Prefab")]
    static void CreaPrefab()
    {
        GameObject obj = Selection.activeGameObject;

        //Donde lo vas a guardar
        string Path = "Assets/Prefabs/" + obj.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(obj, Path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    [MenuItem("Utilidades/Pinta Jerarquia")]
    static void PintaJerarquia()
    {
        GameObject guis = new GameObject();
        guis.name = Cambiacandena("GUI");
        GameObject estaticos = new GameObject();
        estaticos.name = Cambiacandena("Estaticos");
        GameObject interactivos = new GameObject();
        interactivos.name = Cambiacandena("Interactivos");
    }
    static string Cambiacandena(string nombre)
    {
        return "-------" + nombre + "------";
    }
    [MenuItem("Utilidades/Crea Carpetas")]
    static void CreaCarpetas()
    {
        AssetDatabase.CreateFolder("Assets", "Animation");
        AssetDatabase.CreateFolder("Assets", "Animator");
        AssetDatabase.CreateFolder("Assets", "Editor");
        AssetDatabase.CreateFolder("Assets", "Font");
        AssetDatabase.CreateFolder("Assets", "Materials");
        AssetDatabase.CreateFolder("Assets", "Models");
        AssetDatabase.CreateFolder("Assets", "Prefabs");
          AssetDatabase.CreateFolder("Assets", "Resources");
            AssetDatabase.CreateFolder("Assets", "Scenes");
              AssetDatabase.CreateFolder("Assets", "Scripts");
              AssetDatabase.CreateFolder("Assets", "Shaders");
              AssetDatabase.CreateFolder("Assets", "Skins");
               AssetDatabase.CreateFolder("Assets", "Sounds");
                AssetDatabase.CreateFolder("Assets", "Sprites");
                AssetDatabase.CreateFolder("Assets", "Textures");
    }
    [MenuItem("Utilidades/Crea Paquete")]
    static void CreaCarpeta()
    {
        AssetDatabase.CreateFolder("Package", "Utilidades");
 
    }

}

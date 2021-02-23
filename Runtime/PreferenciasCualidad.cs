using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PreferenciasCualidad : MonoBehaviour
{
    TMP_Dropdown dropdown;
    List<TMP_Dropdown.OptionData> Opciones;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [ContextMenu("Rellena")]
    void Rellena()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.name = "Preferencias";

        //Creamos las opciones
        /*
        TMP_Dropdown.OptionData opcion1 = new TMP_Dropdown.OptionData();
        opcion1.text = "Muy baja";
        Opciones.Add(opcion1);

        TMP_Dropdown.OptionData opcion2 = new TMP_Dropdown.OptionData();
        opcion2.text = "Baja";
        Opciones.Add(opcion2);

        TMP_Dropdown.OptionData opcion3 = new TMP_Dropdown.OptionData();
        opcion3.text = "Media";
        Opciones.Add(opcion3);

        TMP_Dropdown.OptionData opcion4 = new TMP_Dropdown.OptionData();
        opcion3.text = "Media";
        Opciones.Add(opcion3);*/

        string[] Nombres = QualitySettings.names;
        foreach(string n in Nombres)
        {
            TMP_Dropdown.OptionData op = new TMP_Dropdown.OptionData();
            op.text = n;
            Opciones.Add(op);
        }

        dropdown.options = Opciones;

        //Marca el Quality por defecto
        dropdown.SetValueWithoutNotify(QualitySettings.GetQualityLevel());
     
    }
    public void CambiaPreferencia(int id)
    {
        QualitySettings.SetQualityLevel(id);
    }
}

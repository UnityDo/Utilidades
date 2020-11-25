using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : MonoBehaviour
{
    public GameObject ladrilloBase;
    public Transform posInicio;
    [SerializeField]
    int ladrilloFila=11;
    [SerializeField]
    int ladrilloColumna = 3;
    //Donde 1 hay ladrillo 0 es un hueco
    int[,] Patron = { { 1, 0, 1}, 
                       { 1, 0, 1 }, 
                        { 1, 0, 1} };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Crea Ladrillo Fila")]
    void CreaLineaLadrillos()
    {
        Vector2 pos_aux = Vector2.zero;
        for (int i = 0; i < ladrilloFila; i++)
        {
           GameObject clon_ladrillo= Instantiate(ladrilloBase, posInicio.position, Quaternion.identity) as GameObject;
            //la posicion del obclon_ladrillojeto 
            pos_aux.x = posInicio.position.x + clon_ladrillo.GetComponent<Collider2D>().bounds.size.x*i;
            pos_aux.y = posInicio.position.y;
            clon_ladrillo.transform.position = pos_aux;

        }
      
    }
    [ContextMenu("Crea Ladrillo Fila y Columna")]
    void CreaLineaYColumnaLadrillos()
    {
        Vector2 pos_aux = Vector2.zero;
        //Repetir por el numero de columnas
        for (int j = 0; j < ladrilloColumna; j++)
        {
            for (int i = 0; i < ladrilloFila; i++)
            {
                

                GameObject clon_ladrillo = Instantiate(ladrilloBase, posInicio.position, Quaternion.identity) as GameObject;
                //la posicion del obclon_ladrillojeto 
                pos_aux.x = posInicio.position.x + clon_ladrillo.GetComponent<Collider2D>().bounds.size.x * i;
                pos_aux.y= posInicio.position.y + clon_ladrillo.GetComponent<Collider2D>().bounds.size.y * j;
                clon_ladrillo.transform.position = pos_aux;

            }        
        }    
    }

    [ContextMenu("Crea con Patron")]
    void CreaConPatron()
    {
        Vector2 pos_aux = Vector2.zero;
        float ancho = ladrilloBase.GetComponent<SpriteRenderer>().bounds.size.x;
        float alto = ladrilloBase.GetComponent<SpriteRenderer>().bounds.size.y;
       
        
        //Repetir por el numero de columnas
        for (int j = 0; j <Patron.GetLength(1); j++)
        {
            for (int i = 0; i < Patron.GetLength(0); i++)
            {    
                pos_aux.x = posInicio.position.x + ancho * j;
                pos_aux.y = posInicio.position.y - alto * i;
            
                //Construye solo si es un 1
                if (Patron[i, j] == 1)
                {
                    GameObject clon_ladrillo = Instantiate(ladrilloBase, pos_aux, Quaternion.identity) as GameObject;
                    
                }                                            
            }
         
        }
    }
    [ContextMenu("Destruye Ladrillos")]
    void DestruyeLadrillos()
    {
        //Recoger todos los objetos con el tag Ladrillo
       GameObject[] Ladrillos= GameObject.FindGameObjectsWithTag("Ladrillo");
        foreach(GameObject ladrillo in Ladrillos)
        {
            //En tiempo de juego
            // Destroy(ladrillo)
            //En tiempo de edicion
            DestroyImmediate(ladrillo);
        }
    }
}

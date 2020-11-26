using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorLadrillos : MonoBehaviour {
	public GameObject[] ladrillos_base;
	public Transform pos_inicial;
	static int[,] patron=new int[,]{{0,0,0,9,0},{0,1,1,1,1},{9,2,2,2,2}};

	public Texture2D imagen;
	Color32[] Colores;
	// Use this for initialization
	void Start () {
		//CreaLadrillosFila ();
		CreaLadrillosFilayColumna ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void CreaLadrillosFila(){
		Vector2 pos_aux=Vector2.zero;
		for (int i = 0; i < ladrillos_base.Length; i++) {
			//GameObject clon_ladrillo = Instantiate (ladrillos_base [i]) as GameObject;
			//GameObject clon_ladrillo = Instantiate (ladrillos_base [i],pos_inicial.position,Quaternion.identity) as GameObject;

			pos_aux.x += pos_inicial.position.x+ladrillos_base [i].GetComponent<SpriteRenderer> ().bounds.size.x;
			pos_aux.y = pos_inicial.position.y;
			GameObject clon_ladrillo = Instantiate (ladrillos_base [i],pos_aux,Quaternion.identity) as GameObject;

		}
	}
	public void CreaLadrillosFilayColumna(){
		Vector2 pos_aux=Vector2.zero;
		int numero_columnas = 5;
		for (int j = 0; j < numero_columnas; j++) {
			for (int i = 0; i < ladrillos_base.Length; i++) {
				//GameObject clon_ladrillo = Instantiate (ladrillos_base [i]) as GameObject;
				//GameObject clon_ladrillo = Instantiate (ladrillos_base [i],pos_inicial.position,Quaternion.identity) as GameObject;

				pos_aux.x += pos_inicial.position.x+ladrillos_base [i].GetComponent<SpriteRenderer> ().bounds.size.x;

				GameObject clon_ladrillo = Instantiate (ladrillos_base [i],pos_aux,Quaternion.identity) as GameObject;

			}
			pos_aux.y -= pos_inicial.position.y + ladrillos_base [j].GetComponent<SpriteRenderer> ().bounds.size.y;
			pos_aux.x = 0;
		}

	}
	public void CreaLadrillosImagen(){

		Colores = imagen.GetPixels32 ();

		int cont = 0;
		float altura = ladrillos_base[0].GetComponent<SpriteRenderer> ().bounds.size.y;
		float anchura = ladrillos_base[0].GetComponent<SpriteRenderer> ().bounds.size.x;

		for (int i = 0; i < imagen.height; i++) {
			for (int j = 0; j < imagen.width; j++) {
				if (Colores [cont] != Color.white) {
					ladrillos_base [0].GetComponent<SpriteRenderer> ().color = Colores [cont];
					Vector2 nueva_pos = new Vector2 (anchura * j+pos_inicial.position.x, altura * i+pos_inicial.position.y);
					GameObject clon_ladrillo = Instantiate (ladrillos_base [0], nueva_pos, Quaternion.identity) as GameObject;
				}
				cont++;
			}
		}
	
	
	}
	public void CreaConPatron(){
		Vector2 pos_aux=Vector2.zero;
		float altura = ladrillos_base[0].GetComponent<SpriteRenderer> ().bounds.size.y;
		float anchura = ladrillos_base[0].GetComponent<SpriteRenderer> ().bounds.size.x;
		int cont = 0;
		for (int j = 0; j < patron.GetLength (1); j++) {
			for (int i = 0; i < patron.GetLength (0); i++) {
				pos_aux.x += pos_inicial.position.x + anchura;
				if (patron [i, j] != 9) {
					
					GameObject nuevo = (GameObject)Instantiate (ladrillos_base [patron [i, j]], pos_aux, Quaternion.identity);
					cont++;

				}

			}
			pos_aux.y -= pos_inicial.position.y + altura;
			pos_aux.x = 0;

		}
	}
	public void BorraLadrillos(){
	//Buscar todos los elementos que tienen el tag ladrillo
		GameObject[] ladrillos_copia=GameObject.FindGameObjectsWithTag("Ladrillo");

		foreach (GameObject l in ladrillos_copia) {
			DestroyImmediate (l,true);
		}
			
		
	}
}


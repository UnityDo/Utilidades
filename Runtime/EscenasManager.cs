using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasManager : MonoBehaviour
{
	public void CambiaEscena( int idEscena )
	{
		SceneManager.LoadScene( idEscena );
	}

	public void CambiaEscena( string escena )
	{
		SceneManager.LoadScene( escena );
	}

	public void Salir()
	{
		Application.Quit();
	}
}

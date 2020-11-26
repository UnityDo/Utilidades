using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    const float velocidadFade = 2f;
    const float velocidadScale = 1f;
    public CanvasGroup grupoFade;
    public CanvasGroup grupoScale;
    bool fadeCompletado;
    bool scaleCompletado;
    public bool estaActivo = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive( estaActivo );
    }

    public void Abrir()
    {
        estaActivo = true;
        gameObject.SetActive( true );
        fadeCompletado = false;
        scaleCompletado = false;
        StartCoroutine( FadeIn() );
        StartCoroutine( ScaleIn() );
    }

    public void Cerrar()
    {
        estaActivo = false;
        fadeCompletado = false;
        scaleCompletado = false;
        StartCoroutine( FadeOut() );
        StartCoroutine( ScaleOut() );
    }

    IEnumerator FadeIn()
    {
        // de 0 a 1
        for( float alfa = 0; alfa <= 1f; alfa += Time.unscaledDeltaTime * velocidadFade ) {
            grupoFade.alpha = alfa;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        // de 1 a 0
        for( float alfa = 1; alfa >= 0; alfa -= Time.unscaledDeltaTime * velocidadFade ) {
            grupoFade.alpha = alfa;
            grupoScale.transform.localScale = new Vector3( alfa, alfa, 1 );
            yield return null;
        }
        fadeCompletado = true;
        Completado( false );
    }

    IEnumerator ScaleIn()
    {
        // de 0 a 1
        for( float alfa = 0; alfa <= 1f; alfa += Time.unscaledDeltaTime * velocidadScale ) {
            float elastic = EaseOutElastic( alfa );
            grupoScale.transform.localScale = new Vector3( elastic, elastic, 1 );
            yield return null;
        }
    }

    IEnumerator ScaleOut()
    {
        // de 1 a 0
        for( float alfa = 1; alfa >= 0; alfa -= Time.unscaledDeltaTime * velocidadFade ) {
            float elastic = EaseOutBack( alfa );
            grupoScale.transform.localScale = new Vector3( elastic, elastic, 1 );
            yield return null;
        }
        scaleCompletado = true;
        Completado( false );
    }

    float EaseOutElastic( float x )
    {
        const float c4 = (2 * Mathf.PI) / 3;

        return x == 0
          ? 0
          : x == 1
          ? 1
          : Mathf.Pow( 2, -10 * x ) * Mathf.Sin( (x * 10 - 0.75f) * c4 ) + 1;
    }

    float EaseOutBack( float x )
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow( x - 1, 3 ) + c1 * Mathf.Pow( x - 1, 2 );
    }

    void Completado( bool activar )
    {
        if( fadeCompletado && scaleCompletado ) {
            gameObject.SetActive( activar );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControlSonido : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider fxslider, musicaslider;
    // Start is called before the first frame update
    void Start()
    {
        //Sin volumen no es 0 , -80 db y 20db , lo normal es 0 y sin -80
        VolumenFx(PlayerPrefs.GetFloat("FxVolumen"));
        VolumenMusica(PlayerPrefs.GetFloat("MusicaVolumen"));
        fxslider.value = PlayerPrefs.GetFloat("FxVolumen");
        musicaslider.value = PlayerPrefs.GetFloat("MusicaVolumen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VolumenFx(float volumen)
    {
        audioMixer.SetFloat("FxVolumen", volumen);
        PlayerPrefs.SetFloat("FxVolumen", volumen);      
    }
    public void VolumenMusica(float volumen)
    {
        audioMixer.SetFloat("MusicaVolumen", volumen);
        PlayerPrefs.SetFloat("MusicaVolumen", volumen);
    }
}

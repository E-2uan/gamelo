using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioMixer AudioMix;
    public Slider musicSlider;
    public Slider soundSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVol(); 
        }
          
        else setMusicVol();
    }
    public void setMusicVol()
    {
        AudioMix.SetFloat("MusicVol",musicSlider.value);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void LoadMusicVol()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        setMusicVol();
    }
    public void setSoundvol()
    {
        AudioMix.SetFloat("SoundVol",soundSlider.value);
    }
}
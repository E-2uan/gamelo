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
   
    public void setMusicVol()
    {
        AudioMix.SetFloat("MusicVol",musicSlider.value);
    }
    public void setSoundvol()
    {
        AudioMix.SetFloat("SoundVol",soundSlider.value);
    }
}
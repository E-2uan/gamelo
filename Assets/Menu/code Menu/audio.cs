using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class audio : MonoBehaviour
{   
    //Bien luu tru AudioSource
    public AudioSource musicAudio;
    public AudioSource sfxAudio;

    //bien luu tru AudioClip
    public AudioClip musicCLip;
    public AudioClip sfxClip;

    // Start is called before the first frame update
    void Start()
    {
        musicAudio.clip= musicCLip; ;
        musicAudio.Play();
    }
    public void btnStart(AudioClip nutClip)
    { 
        sfxAudio.clip= nutClip;
        sfxAudio.PlayOneShot(nutClip);
    }
  
}

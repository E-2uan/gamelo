using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class SoundManager: MonoBehaviour
{
    //bien truy cap vao nguon am thanh
    public static SoundManager instance { get; private set; }

    //Bien luu tru AudioSource
    public AudioSource musicAudio;
    public AudioSource sfxAudio;

    //bien luu tru AudioClip
    public AudioClip musicCLip;

    private void Awake()
    {
        instance = this;
        sfxAudio = GetComponent<AudioSource>();
    }

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

    //ham chay sound
    public void PlaySoundOneShot(AudioClip sound)
    {
        sfxAudio.PlayOneShot(sound);
    }
}

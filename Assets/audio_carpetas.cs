using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_carpetas: MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public float delay = 0.1f;
    public bool esLoop = false;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("playSound", delay);
    }

    private void playSound()
    {
        if (esLoop)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
        }
        
    }


}

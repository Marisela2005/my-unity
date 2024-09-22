using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarGameOver : MonoBehaviour
{
    public GameObject camaraGameOver;
    public AudioClip gameOverClip;

    // Start is called before the first frame update
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }

    void PersonajeHaMuerto(Notification notification)
    {
        AudioSource cameraAudioSource = Camera.main.GetComponent<AudioSource>();
        if (cameraAudioSource != null)
        {
            cameraAudioSource.Stop();
        }
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = gameOverClip;
        audioSource.loop = false;
        audioSource.Play();
        camaraGameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

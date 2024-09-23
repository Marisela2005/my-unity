using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCargarEscena : MonoBehaviour
{
    public string nombreEscenaParaCarga = "GameScene";
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (Camera.main.GetComponent<AudioSource>() != null)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
        }
        if (audioSource != null)
        {
            audioSource.Play();
            Invoke("CargarNivelJuego", audioSource.clip.length);
        }
    }
    void CargarNivelJuego()
    {
        SceneManager.LoadScene(nombreEscenaParaCarga);
    }
}

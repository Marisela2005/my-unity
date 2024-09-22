using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int puntosGanados = 5;
    public AudioClip itemSoundClip;
    public float itemSoundVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
            AudioSource.PlayClipAtPoint(itemSoundClip, Camera.main.transform.position, itemSoundVolume);
        }
        Destroy(gameObject);
    }
}

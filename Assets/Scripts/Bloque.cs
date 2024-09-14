using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    private bool haColisionadoConElJugador = false;
    public int puntosGanados = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!haColisionadoConElJugador && collision.gameObject.tag == "Player")
        {
            GameObject obj = collision.contacts[0].collider.gameObject;
            if(obj.name == "PataInferiorDerechaB")
            {
                haColisionadoConElJugador = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
            }
        }
    }
}

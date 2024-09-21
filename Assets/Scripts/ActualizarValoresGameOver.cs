using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualizarValoresGameOver : MonoBehaviour
{
    public TextMesh total;
    public TextMesh record;
    public Puntuacion puntuacion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        total.text = puntuacion.puntuacion.ToString();
        record.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
    }
}

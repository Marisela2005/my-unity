using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] obj;
    public float tiempoMin = 1.25f;
    public float tiempoMax = 2.75f;

    // Start is called before the first frame update
    void Start()
    {
        Generar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
    
    }
}

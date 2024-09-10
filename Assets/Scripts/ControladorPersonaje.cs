using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public float fuerzaSalto = 100f;
    private Rigidbody2D rb;
    private bool enSuelo = true;
    public Transform comprobadorSuelo;
    private float comprobadorRadio = 0.07f;
    public LayerMask mascaraSuelo;
    private bool dobleSalto = false;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        animator.SetBool("isGrounded", enSuelo);
        if(enSuelo)
        {
            dobleSalto = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((enSuelo || !dobleSalto) && Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            // Aplica la fuerza al Rigidbody2D del objeto
            // rb.AddForce(new Vector2(0, fuerzaSalto));
            if(!dobleSalto && !enSuelo)
            {
                dobleSalto = true;
            }
        }
    }
}

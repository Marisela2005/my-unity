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
    private bool corriendo = false;
    public float velocidad = 1f;

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
        if (corriendo)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        animator.SetFloat("VelX", rb.velocity.x);
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
        if (Input.GetMouseButtonDown(0))
        {
            if (corriendo)
            {
                // Hacemos que salte si puede saltar
                if (enSuelo || !dobleSalto)
                {
                    rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                    // Aplica la fuerza al Rigidbody2D del objeto
                    // rb.AddForce(new Vector2(0, fuerzaSalto));
                    if (!dobleSalto && !enSuelo)
                    {
                        dobleSalto = true;
                    }
                }
            }
            else
            {
                corriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
            }
        }
    }
}

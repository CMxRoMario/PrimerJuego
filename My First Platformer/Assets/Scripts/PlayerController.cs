using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float velocidad;
    public float fuerzaDeSalto;
    public LayerMask mascaraDePiso;


    private Rigidbody2D rb;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Correr();

        if (estaEnElPiso() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);
        }
    }

    private void Correr()
    {
        float inputJugador = Input.GetAxisRaw("Horizontal");
        float velocidadObjetivo = inputJugador * velocidad;
        float diferenciaVelocidad = velocidadObjetivo - rb.velocity.x;

        rb.AddForce(Vector2.right * diferenciaVelocidad);

        Debug.DrawRay(transform.position, rb.velocity, Color.red);
        Debug.DrawRay(transform.position, new Vector3(velocidadObjetivo, 0), Color.blue);
    }

    private bool estaEnElPiso()
    {
        RaycastHit2D centro = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + 0.1f, mascaraDePiso);

        return centro.collider != null;

    }

}
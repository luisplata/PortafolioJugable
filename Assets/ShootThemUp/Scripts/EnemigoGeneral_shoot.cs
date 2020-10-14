using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemigoGeneral_shoot : MonoBehaviour
{
    /*
     funciones comunes:
     moverse hacia abajo
     buscar al player para dispararle
     una abstracta para decidir como disparar
     cantidad de puntos
     referencia a la UI
     */
    [SerializeField] protected ControladorDeUiShotThemUp ui;
    [SerializeField] protected float velocidadDeBajada;
    [SerializeField] protected float aumentoDeVelocidad;
    [SerializeField] protected int vida;
    protected Rigidbody2D rb;
    protected Animator anim;

    public void AumentarDificultad()
    {
        velocidadDeBajada *= aumentoDeVelocidad;
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ui = GameObject.Find("Canvas").GetComponent<ControladorDeUiShotThemUp>();
    }

    public abstract int GetPuntuacion();

    protected abstract Vector2 MovimientoHaciaAbajo();

    protected void Update()
    {
        rb.velocity = MovimientoHaciaAbajo();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balaPlayer"))
        {
            LePegaronAlEnemigo(collision.gameObject.GetComponent<BalaPlayerShoot>());
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared"))
        {
            Destroy(gameObject);
        }
    }

    protected void LePegaronAlEnemigo(BalaPlayerShoot bala)
    {
        vida -= bala.GetPoderDeBala();

        if (vida <= 0)
        {
            ui.ActualizarPuntuacionGeneral(this);
            anim.SetTrigger("murio");
        }
    }
    private void TerminoDeMorir()
    {
        Destroy(gameObject);
    }
}

using System;
using UnityEngine;

public abstract class BloqueDestructibleGenerico : MonoBehaviour
{
    protected ControladorDeSonido controladorDeSonido;
    protected Animator animador;
    protected SpriteRenderer sprite;
    protected LogicaDeBloquesDestructibles logica;

    protected void Start()
    {
        sprite = transform.Find("GameObject").GetComponent<SpriteRenderer>();
        controladorDeSonido = GameObject.Find("SFX").GetComponent<ControladorDeSonido>();
        animador = GetComponent<Animator>();
        logica = new LogicaDeBloquesDestructibles(this);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        logica.CuandoElPlayerNosPegaConLaCabeza(collision.gameObject.CompareTag("cabeza"));
    }

    public abstract void CuandoLePeganAlBloque();

    protected abstract void SeTerminoLaAnimacion();
}

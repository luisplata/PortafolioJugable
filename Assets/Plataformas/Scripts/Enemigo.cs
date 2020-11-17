using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour, ILogicaDeMovimientoDelEnemigo
{
    [SerializeField] private float speed;
    public float potenciaDeSaltoDeMario;
    [SerializeField]
    private LogicaPlataformaDeMovimientoEnemigo logica;

    private void Start()
    {
        logica = new LogicaPlataformaDeMovimientoEnemigo(speed, this);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = logica.CalcularDireccionDeMovimientoDelEnemigo();
    }

    public float GetVelocidadDeY()
    {
        return GetComponent<Rigidbody2D>().velocity.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logica.DebeCambiarDeLadoCuandoColisione(collision.gameObject.CompareTag("obstaculo"), collision.gameObject.CompareTag("enemigo"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logica.ColisionoConLaParteQueMataDelPlayer(collision.gameObject.CompareTag("pie"), collision.gameObject.transform.parent.gameObject.GetComponent<IMovimientoPlayerPlataformas>());
    }

    public void AccionesContraElPlayerEnUnity(IMovimientoPlayerPlataformas componenteNecesitado)
    {
        GetComponent<Animator>().SetTrigger("morir");
        float potencia = (potenciaDeSaltoDeMario / 100);
        componenteNecesitado.Saltar(1.5f);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Morir()
    {
        Destroy(gameObject);
    }
}

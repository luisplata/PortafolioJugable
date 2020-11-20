using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer_shoot : MonoBehaviour, IMovimientoPlayerShootMono
{
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private int cantidadDisparosSimultaneos;
    [SerializeField] private GameObject disparoPrefab, disparoPowerUpPrefabs;
    private Rigidbody2D rb;
    private Animator anim;
    private InputManager inputManager;
    private LogicaDeMovimientoPlayerShoot logica;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inputManager = GameObject.Find("MenuDePausa").GetComponent<InputManager>();
        logica = new LogicaDeMovimientoPlayerShoot(this, velocidadDeMovimiento, cantidadDisparosSimultaneos);
    }

    private void Update()
    {
        var movimientoX = inputManager.SeMovioHorizontalmente();
        var movimientoY = inputManager.SeMovioVerticalmente();

        rb.velocity = logica.CalculandoMovimientoDelPlayer(movimientoX, movimientoY, Time.deltaTime);

        anim.SetFloat("horizontal", movimientoX);
        anim.SetFloat("vertical", movimientoY);

        logica.ElPlayerDisparo(inputManager.SeprecionoElBoton(InputDefinidosParaElJuego.Launch));
    }

    private void TerminoDeMorir()
    {
        Destroy(gameObject);
    }

    public void Disparar()
    {
        if(logica.PuedeDisparar(GameObject.FindGameObjectsWithTag("balaPlayer").Length))
        {
            GameObject disparo = Instantiate(disparoPrefab, transform);
            disparo.transform.parent = null;
        }
    }
}

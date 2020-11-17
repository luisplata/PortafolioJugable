using System;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour, IMovimientoPlayerPlataformas
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float speedJump;
    [SerializeField] InputManager inputManager;
    private LogicaDeMovimientoPlayer ligicaDeMovimientoPlayer;
    private bool salto;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        inputManager = GameObject.Find("MenuDePausa").GetComponent<InputManager>();
        ligicaDeMovimientoPlayer = new LogicaDeMovimientoPlayer(this, velocidadMovimiento);
    }


    private void Update()
    {
        float movimientoHorizontal = inputManager.SeMovioHorizontalmente();
        ligicaDeMovimientoPlayer.DebeFlipearElSpriteDelPersonaje(movimientoHorizontal);

        rb.velocity = ligicaDeMovimientoPlayer.CalcularVelocidadDelRigiBody(
            movimientoHorizontal, 
            rb.velocity.y, 
            Time.deltaTime
            );

        ligicaDeMovimientoPlayer.Saltar(inputManager.SeprecionoElBoton(InputDefinidosParaElJuego.Launch));
    }
    public void FlipearElEjeX(bool debeFlipear)
    {
        sprite.flipX = debeFlipear;
    }

    public void Saltar()
    {
        Saltar(1);
    }

    public void Saltar(float porcentaje)
    {
        rb.AddForce(Vector2.up * (speedJump * porcentaje));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ligicaDeMovimientoPlayer.Salto = false;
    }
}

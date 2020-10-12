using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float speedJump;
    [SerializeField] InputManager inputManager;
    private bool salto;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        inputManager = GameObject.Find("MenuDePausa").GetComponent<InputManager>();
    }


    private void Update()
    {
        float movimientoHorizontal = inputManager.SeMovioHorizontalmente();
        if (movimientoHorizontal != 0)
        {
            if(movimientoHorizontal > 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        float velocidadX = velocidadMovimiento * movimientoHorizontal * Time.deltaTime;
        float velocidadY = rb.velocity.y;
        rb.velocity = new Vector2(velocidadX, velocidadY);
        if (inputManager.SeprecionoElBoton(InputDefinidosParaElJuego.Launch) && !salto)
        {
            Saltar();
            salto = true;
        }
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
        salto = false;
    }
}

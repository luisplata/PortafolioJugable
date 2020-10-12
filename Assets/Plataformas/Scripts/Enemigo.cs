using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    private Vector2 velocidad;
    [SerializeField] private bool start = false;
    private bool flip = false;
    public float potenciaDeSaltoDeMario;

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            //derecha
            velocidad = Vector2.left * speed;
            if (flip)
            {
                velocidad *= -1;
            }
            velocidad.y = GetComponent<Rigidbody2D>().velocity.y;
            GetComponent<Rigidbody2D>().velocity = velocidad;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstaculo") || collision.gameObject.CompareTag("enemigo"))
        {
            flip = !flip;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pie"))
        {
            //GameObject.Find("SFX").GetComponent<ControladorDeSonidos>().EjecutarSonido("matarEnemigo");
            start = false;
            GetComponent<Animator>().SetTrigger("morir");
            float potencia = (potenciaDeSaltoDeMario / 100);
            collision.gameObject.transform.parent.gameObject.GetComponent<MovimientoPlayer>().Saltar(1.5f);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Collider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
        }
    }

    public void Morir()
    {
        Destroy(gameObject);
    }
}

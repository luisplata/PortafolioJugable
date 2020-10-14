using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer_shoot : MonoBehaviour
{
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private GameObject disparoPrefab, disparoPowerUpPrefabs;
    private Rigidbody2D rb;
    private Animator anim;
    private InputManager inputManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inputManager = GameObject.Find("MenuDePausa").GetComponent<InputManager>();
    }

    private void Update()
    {
        float movimientoX = inputManager.SeMovioHorizontalmente();
        float movimientoY = inputManager.SeMovioVerticalmente();
        if(movimientoX != 0)
        {
            if(movimientoX > 0)
            {
                //movimientoX = 1;
            }
            else
            {
                //movimientoX = -1;
            }
        }
        if(movimientoY != 0)
        {
            if(movimientoY > 0)
            {
                //movimientoY = 1;
            }
            else
            {
                //movimientoY = -1;
            }
        }

        rb.velocity = new Vector2(movimientoX, movimientoY) * (velocidadDeMovimiento * Time.deltaTime);

        anim.SetFloat("horizontal", movimientoX);
        anim.SetFloat("vertical", movimientoY);
        

        if (inputManager.SeprecionoElBoton(InputDefinidosParaElJuego.Launch))
        {
            Disparar();
        }
    }

    private void TerminoDeMorir()
    {
        Destroy(gameObject);
    }

    public void Disparar()
    {
        if(GameObject.FindGameObjectsWithTag("balaPlayer").Length <= 3)
        {
            GameObject disparo = Instantiate(disparoPrefab, transform);
            disparo.transform.parent = null;
        }
    }
}

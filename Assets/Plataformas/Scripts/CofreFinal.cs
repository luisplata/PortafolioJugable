using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreFinal : MonoBehaviour, IConfreFinalMono
{
    private LogicaCofreFinal logica;
    private Animator anim;

    public void LlamarAnimacionDeApertura()
    {
        anim.SetTrigger("comenzarAbrir");
    }

    // Start is called before the first frame update
    void Start()
    {
        logica = new LogicaCofreFinal(this);
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        logica.ElPlayerTocoElCofre(collision.gameObject.CompareTag("Player"));
    }
}

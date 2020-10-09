using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class EstadosFinitosBase : MonoBehaviour
{

    public abstract void Salir();

    protected ControladorDeEscenaNovelaVisual controlador;

    protected void ColocarTextoEnPantalla(string texto, TextMeshProUGUI caja)
    {
        if(caja.text.Length < texto.Length)
            caja.text = texto.Substring(0, caja.text.Length + 1);
    }

    public virtual void Start()
    {
        controlador = GetComponent<ControladorDeEscenaNovelaVisual>();
        controlador.texto.text = "";
    }

    protected virtual void NormalizamosTextos()
    {
        //buscamos lo que necesitamos
        controlador.texto.gameObject.SetActive(true);
        controlador.panelOpciones.SetActive(false);
        controlador.botonSiguienteGO.gameObject.SetActive(true);
    }

    public abstract void Update();

    public abstract Type VerficarTransiciones();
    
    public void VerificarCambios()
    {
        Type estadoACambiar = VerficarTransiciones();
        if (estadoACambiar != this.GetType())
        {
            CambiarEstado(estadoACambiar);
        }
    }

    public void CambiarEstado(Type nuevoEstado)
    {
        //NormalizamosTextos();
        //salir del estado actual
        Salir();
        //agregamos el componente
        gameObject.AddComponent(nuevoEstado);
        //destuimos el estado viejo
        Destroy(this);
    }
}
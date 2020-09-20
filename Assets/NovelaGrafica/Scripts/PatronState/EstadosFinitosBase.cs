using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class EstadosFinitosBase : MonoBehaviour
{

    public string nombreUtilizado;

    public abstract void Salir();

    public abstract void Opcion1();

    public abstract void Opcion2();

    [SerializeField] protected int indiceDeDialogo;
    [SerializeField] protected int indiceDeDialogoLocal = -1;

    protected bool yaPaso;

    public List<string> dalogos;

    protected ControladorDeEscenaNovelaVisual controlador;

    protected virtual void ColocarTextoEnPantalla(int indiceDeDialogoLocalfuncion)
    {
        if (indiceDeDialogoLocal != this.indiceDeDialogo)
        {
            //cambio de texto
            indiceDeDialogoLocal = this.indiceDeDialogo;
            controlador.texto.text = "";
        }
        //verifcamos que no sean opciones
        if (dalogos[indiceDeDialogoLocal].Split('|').Length > 1)
        {
            ColocarOpcionesEnPantlla(dalogos[indiceDeDialogoLocal].Split('|')[0], dalogos[indiceDeDialogoLocal].Split('|')[1]);
        }
        else if (controlador.texto.text.Length < dalogos[indiceDeDialogoLocal].Length)
        {
            //mostramos una letra
            controlador.texto.text = dalogos[indiceDeDialogoLocal].Substring(0, controlador.texto.text.Length + 1);
        }
        //colcamos letra por letra en el dialogo

    }

    public virtual void Start()
    {
        controlador = GetComponent<ControladorDeEscenaNovelaVisual>();
        dalogos = new List<string>();
        indiceDeDialogo = 0;
        controlador.botonSiguiente.onClick.AddListener(delegate { BotonSiguiente(); });
        yaPaso = false;
        NormalizamosTextos();
    }

    protected virtual void ColocarOpcionesEnPantlla(string v1, string v2)
    {
        //buscamos lo que necesitamos
        controlador.texto.gameObject.SetActive(false);
        controlador.panelOpciones.SetActive(true);

        TextMeshProUGUI opcion11 = controlador.opcion1.GetComponent<TextMeshProUGUI>();
        opcion11.text = v1;
        Button opcion111 = controlador.opcion1.GetComponent<Button>();
        opcion111.onClick.AddListener(delegate { Opcion1(); });

        TextMeshProUGUI opcion22 = controlador.opcion2.GetComponent<TextMeshProUGUI>();
        opcion22.text = v2;
        Button opcion222 = controlador.opcion2.GetComponent<Button>();
        opcion222.onClick.AddListener(delegate { Opcion2(); });

        //desabilitamos el boton siguiente
        controlador.botonSiguienteGO.SetActive(false);
    }

    protected virtual void NormalizamosTextos()
    {
        //buscamos lo que necesitamos
        controlador.texto.gameObject.SetActive(true);
        controlador.panelOpciones.SetActive(false);
        controlador.botonSiguienteGO.SetActive(true);
    }

    public virtual void BotonSiguiente()
    {
        this.indiceDeDialogo++;
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
        //salir del estado actual
        Salir();
        //agregamos el componente
        gameObject.AddComponent(nuevoEstado);
        //destuimos el estado viejo
        Destroy(this);
    }
}

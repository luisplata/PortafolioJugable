using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public abstract class AccionDeOpciones : AccionGenerica
{
    protected bool pasarAlSiguienteDialogo;
    protected List<string> opciones;

    protected virtual void ColocarOpcionesEnPantlla(List<string> opciones)
    {
        if(opciones.Count <= 0)
        {
            throw new Exception("No hay opciones que mostrar");
        }

        //buscamos lo que necesitamos
        controlador.texto.gameObject.SetActive(false);
        controlador.panelOpciones.SetActive(true);

        if (opciones.Count > 0)
        {
            TextMeshProUGUI opcion11 = controlador.opcion1.GetComponent<TextMeshProUGUI>();
            opcion11.text = opciones[0];
            Button opcion111 = controlador.opcion1.GetComponent<Button>();
            opcion111.onClick.AddListener(delegate { Opcion1(); });
        }
        if(opciones.Count > 1)
        {
            TextMeshProUGUI opcion22 = controlador.opcion2.GetComponent<TextMeshProUGUI>();
            opcion22.text = opciones[1];
            Button opcion222 = controlador.opcion2.GetComponent<Button>();
            opcion222.onClick.AddListener(delegate { Opcion2(); });
        }

        if(opciones.Count > 2)
        {
            TextMeshProUGUI opcion33 = controlador.opcion3.GetComponent<TextMeshProUGUI>();
            opcion33.text = opciones[2];
            Button opcion333 = controlador.opcion3.GetComponent<Button>();
            opcion333.onClick.AddListener(delegate { Opcion3(); });
        }

        //desabilitamos el boton siguiente
        controlador.botonSiguienteGO.gameObject.SetActive(false);
    }

    public abstract void Opcion1();
    public abstract void Opcion2();
    public abstract void Opcion3();
}
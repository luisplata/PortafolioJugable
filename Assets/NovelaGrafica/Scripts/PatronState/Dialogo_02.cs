﻿using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Dialogo_02 : AccionDeOpciones
{
    public override void Start()
    {
        base.Start();
        dialogo = "Ahora, cuentame que quieres hacer?";
        opciones = new List<string>
        {
            "Saber mas sobre mi.",
            "Conocer mi información academica.",
            "Ver mi experiencia laboral."
        };
    }

    public override void Salir()
    {
        NormalizamosTextos();
    }

    public override void Update()
    {
        ColocarTextoEnPantalla(dialogo, controlador.texto);
        VerificarCambios();
        if (finalizoAccion)
        {
            ColocarOpcionesEnPantlla(opciones);
            finalizoAccion = false;
        }
    }

    public override Type VerficarTransiciones()
    {
        if (pasarAlSiguienteDialogo)
        {
            return GetType();
        }
        return GetType();
    }

    public override void Opcion1()
    {
        CargarEscena((int)EscenasDelJuego.PLATAFORMAS);
    }

    private void CargarEscena(int escena)
    {
        //hay que correr un timeline para posteriormente cambiar
        //por ahora esto
        SceneManager.LoadScene(escena);
    }

    public override void Opcion2()
    {
        
    }

    public override void Opcion3()
    {
        
    }
}
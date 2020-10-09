using UnityEngine;
using System.Collections;
using System;

public class Dialogo_00 : AccionTextoNormal
{
    public override void Start()
    {
        base.Start();
        dialogo = "Hola mi nombre es Luis Plata mucho gusto, voy a ser tu guía en esta que es mi hoja de vida.";
    }
    
    public override void Salir()
    {
        
    }

    public override void Update()
    {
        VerificarCambios();
        ColocarTextoEnPantalla(dialogo, controlador.texto);
    }

    public override Type VerficarTransiciones()
    {
        if (finalizoAccion)
        {
            return typeof(Dialogo_01);
        }
        return GetType();
    }
}
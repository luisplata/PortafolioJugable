using System;
using UnityEngine;

public class EstadoDeDialogo01Presentacion : EstadosFinitosBase
{
    public override void Start()
    {
        base.Start();
        dalogos.Add("Hola soy Luis Plata, pero me puedes decir PeryLoth.");
        dalogos.Add("Luis Plata|PeryLoth");//eleccion
        dalogos.Add("Seré tu asistente en esto que será mi portafolio.");
    }
    public override void Salir()
    {
        
    }

    public override void Update()
    {
        VerificarCambios();
        ColocarTextoEnPantalla(indiceDeDialogoLocal);
    }

    public override Type VerficarTransiciones()
    {
        if(this.indiceDeDialogo > (dalogos.Count - 1))
        {
            return typeof(EstadoDeDialogo02Links);
        }
        return GetType();
    }


    public override void Opcion1()
    {
        nombreUtilizado = "Luis Plata";
        if (!yaPaso)
        {
            yaPaso = true;
            this.indiceDeDialogo++;
            NormalizamosTextos();
        }
    }

    public override void Opcion2()
    {
        nombreUtilizado = "PeryLoth";
        if (!yaPaso)
        {
            yaPaso = true;
            this.indiceDeDialogo++;
            NormalizamosTextos();
        }
    }

}
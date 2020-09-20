using System;
using UnityEngine;

public class EstadoDeDialogo02Links : EstadosFinitosBase
{
    public override void Start()
    {
        base.Start();
        dalogos.Add("Aqui puedes encontrar:");
        dalogos.Add("(Github)[https://]|(Página Personal)[https://]");
    }
    public override void Salir()
    {
        
    }

    public override void Opcion1()
    {
        if (!yaPaso)
        {
            yaPaso = true;
            this.indiceDeDialogo++;
            NormalizamosTextos();
        }
    }

    public override void Opcion2()
    {
        if (!yaPaso)
        {
            yaPaso = true;
            this.indiceDeDialogo++;
            NormalizamosTextos();
        }
    }

    public override void Update()
    {
        ColocarTextoEnPantalla(indiceDeDialogoLocal);
        VerificarCambios();
    }

    public override Type VerficarTransiciones()
    {
        if (this.indiceDeDialogo > (dalogos.Count - 1))
        {
            return typeof(EstadoDeDialogo01Presentacion);
        }
        return GetType();
    }
}

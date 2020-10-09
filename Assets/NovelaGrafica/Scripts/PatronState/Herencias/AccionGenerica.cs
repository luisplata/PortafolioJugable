using System;
using UnityEngine;
public abstract class AccionGenerica : EstadosFinitosBase
{
    protected string dialogo;
    [SerializeField] protected bool finalizoAccion = false;

    public override void Start()
    {
        base.Start();
        controlador.botonSiguiente.onClick.AddListener(delegate { BotonSiguiente(); });
    }

    public void BotonSiguiente()
    {
        finalizoAccion = true;
    }
}
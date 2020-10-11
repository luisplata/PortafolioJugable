using Assets.Scripts.ModuloSonidosDelJuego;
using UnityEngine;

public class SonidosFacotry
{
    private readonly SonidosConfiguration configuracion;

    public SonidosFacotry(SonidosConfiguration configuracion)
    {
        this.configuracion = configuracion;
    }

    public SonidoParaSonar Create(EnumSonidosParaSonar sonido)
    {
        return GameObject.Instantiate(configuracion.GetSonidoPrefabById(sonido));
    }
}

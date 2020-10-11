using Assets.Scripts.ModuloSonidosDelJuego;
using UnityEngine;

public class ManejadorDeSonidoConVWise : IManejadorDeSonidosDelJuego
{
    [SerializeField] SonidosConfiguration configuracionSonido;
    public override void TocarCancion(EnumSonidosParaSonar sonido)
    {
        //implementamos una Factoria
        SonidosFacotry factoriaDeSonidos = new SonidosFacotry(GameObject.Instantiate(configuracionSonido));
        SonidoParaSonar sonidoPorSonar = factoriaDeSonidos.Create(sonido);
        //sonidoPorSonar.Evento.Post(gameObject);
        //destruimos el resultante
        Destroy(sonidoPorSonar.gameObject);
    }
}

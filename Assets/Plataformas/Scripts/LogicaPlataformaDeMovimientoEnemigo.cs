using System;
using UnityEngine;

[Serializable]
public class LogicaPlataformaDeMovimientoEnemigo
{
    [SerializeField]
    private bool start;
    public bool Start { get => start; set => start = value; }
    public bool Flip { get; set; }
    public float Speed { get; set; }
    private ILogicaDeMovimientoDelEnemigo logicaMono;

    public LogicaPlataformaDeMovimientoEnemigo(float speed, ILogicaDeMovimientoDelEnemigo mono)
    {
        Start = false;
        Speed = speed;
        logicaMono = mono;
    }

    public Vector2 CalcularDireccionDeMovimientoDelEnemigo()
    {
        Vector2 velocidad = Vector2.zero;
        if (Start)
        {
            velocidad = Vector2.left * Speed;
            if (Flip)
            {
                velocidad *= -1;
            }
        }
        velocidad.y = logicaMono.GetVelocidadDeY();
        return velocidad;
    }
    public void DebeCambiarDeLadoCuandoColisione(bool esObstaculo, bool esEnemigo)
    {
        if (esObstaculo || esEnemigo)
        {
            Flip = !Flip;
        }
    }

    public void ColisionoConLaParteQueMataDelPlayer(bool esElPie, IMovimientoPlayerPlataformas componenteNecesitado)
    {
        if (esElPie)
        {
            Start = false;
            logicaMono.AccionesContraElPlayerEnUnity(componenteNecesitado);
        }
    }
}
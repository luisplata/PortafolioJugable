using System;
using UnityEngine;

public class LogicaDeMovimientoPlayer
{
    private IMovimientoPlayerPlataformas logicaMono;
    public bool Salto { get; set; }
    public float VelocidadMovimiento { get; set; }

    public LogicaDeMovimientoPlayer(IMovimientoPlayerPlataformas mono, float velocidadMov)
    {
        logicaMono = mono;
        VelocidadMovimiento = velocidadMov;
    }
    public void DebeFlipearElSpriteDelPersonaje(float movimientoHorizontal)
    {
        if (movimientoHorizontal != 0)
        {
            if (movimientoHorizontal > 0)
            {
                logicaMono.FlipearElEjeX(false);
            }
            else
            {
                logicaMono.FlipearElEjeX(true);
            }
        }
    }

    public Vector2 CalcularVelocidadDelRigiBody(float x, float y, float deltaTime)
    {
        return new Vector2(CalcularVelocidadDeX(x, deltaTime), CalcularVelocidadDeY(y));
    }

    private float CalcularVelocidadDeY(float y)
    {
        return y;
    }

    private float CalcularVelocidadDeX(float movimientoHorizontal, float deltaTime)
    {
        return VelocidadMovimiento * movimientoHorizontal * deltaTime;
    }

    public void Saltar(bool v)
    {
        if (v && !Salto)
        {
            logicaMono.Saltar();
            Salto = true;
        }
    }
}
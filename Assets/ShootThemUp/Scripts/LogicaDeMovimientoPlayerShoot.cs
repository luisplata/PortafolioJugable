using UnityEngine;

public class LogicaDeMovimientoPlayerShoot
{
    private IMovimientoPlayerShootMono movimientoPlayerShootMono;
    public float VelocidadDeMovimiento { get; set; }
    public int CantidadDisparosSimultaneos { get; set; }

    public LogicaDeMovimientoPlayerShoot(IMovimientoPlayerShootMono movimientoPlayerShootMono, float velocidadMovimiento, int cantidadDisparosSimultaneos)
    {
        this.movimientoPlayerShootMono = movimientoPlayerShootMono;
        VelocidadDeMovimiento = velocidadMovimiento;
        CantidadDisparosSimultaneos = cantidadDisparosSimultaneos;
    }

    public Vector2 CalculandoMovimientoDelPlayer(float movimientoX, float movimientoY, float deltaTime)
    {
        return new Vector2(movimientoX, movimientoY) * (VelocidadDeMovimiento * deltaTime);
    }

    public void ElPlayerDisparo(bool disparo)
    {
        if (disparo)
        {
            movimientoPlayerShootMono.Disparar();
        }
    }

    public bool PuedeDisparar(int length)
    {
        return (length <= CantidadDisparosSimultaneos);
    }
}
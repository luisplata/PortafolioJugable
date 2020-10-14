using UnityEngine;

public class EnemigoGeneralPrimero : EnemigoGeneral_shoot
{
    public override int GetPuntuacion()
    {
        return 2;
    }

    protected override Vector2 MovimientoHaciaAbajo()
    {
        return Vector2.down;
    }
}
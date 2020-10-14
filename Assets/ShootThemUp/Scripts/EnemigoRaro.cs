using UnityEngine;

public class EnemigoRaro : EnemigoGeneral_shoot
{
    public override int GetPuntuacion()
    {
        return 5;
    }

    protected override Vector2 MovimientoHaciaAbajo()
    {
        return Vector2.down;
    }
}
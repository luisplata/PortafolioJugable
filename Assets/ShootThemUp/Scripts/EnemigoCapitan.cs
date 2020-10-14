using UnityEngine;

public class EnemigoCapitan : EnemigoGeneral_shoot
{
    public override int GetPuntuacion()
    {
        return 3;
    }

    protected override Vector2 MovimientoHaciaAbajo()
    {
        return Vector2.down;
    }
}
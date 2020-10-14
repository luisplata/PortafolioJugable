using UnityEngine;

public class EnemigoObrero : EnemigoGeneral_shoot
{
    public override int GetPuntuacion()
    {
        return 1;
    }

    protected override Vector2 MovimientoHaciaAbajo()
    {
        return Vector2.down * (velocidadDeBajada * Time.deltaTime);
    }
}
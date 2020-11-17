using UnityEngine;
public class CajonDePregunta : BloqueDestructibleGenerico
{
    [SerializeField] private Sprite bloqueUsado;

    public override void CuandoLePeganAlBloque()
    {
        controladorDeSonido.EjecutarSonido("tomar_moneda");
        animador.SetTrigger("accion");
    }

    protected override void SeTerminoLaAnimacion()
    {
        sprite.sprite = bloqueUsado;
    }
}
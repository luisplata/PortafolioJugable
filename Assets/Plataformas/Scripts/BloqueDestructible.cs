public class BloqueDestructible : BloqueDestructibleGenerico
{
    protected override void CuandoLePeganAlBloque()
    {
        controladorDeSonido.EjecutarSonido("romper_bloque");
        animador.SetTrigger("destruir");
    }

    protected override void SeTerminoLaAnimacion()
    {
        Destroy(gameObject);
    }
}

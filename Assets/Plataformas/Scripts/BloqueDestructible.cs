public class BloqueDestructible : BloqueDestructibleGenerico
{
    public override void CuandoLePeganAlBloque()
    {
        controladorDeSonido.EjecutarSonido("romper_bloque");
        animador.SetTrigger("destruir");
    }

    protected override void SeTerminoLaAnimacion()
    {
        Destroy(gameObject);
    }
}

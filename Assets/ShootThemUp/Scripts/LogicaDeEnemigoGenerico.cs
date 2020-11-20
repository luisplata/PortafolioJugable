public class LogicaDeEnemigoGenerico
{
    private IEnemigoGenericoMono enemigoGenericoMono;
    private IControlDorDeUiShotThemUp interfazGrafica;
    public float VelocidadDeBajada { get; set; }
    public float AumentoDeVelocidad { get; set; }
    public int Vida { get; set; }

    public LogicaDeEnemigoGenerico(IEnemigoGenericoMono enemigoGeneral_shoot, IControlDorDeUiShotThemUp ui, float velocidadDeBajada, float aumentoDeVelocidad, int vida)
    {
        enemigoGenericoMono = enemigoGeneral_shoot;
        VelocidadDeBajada = velocidadDeBajada;
        AumentoDeVelocidad = aumentoDeVelocidad;
        Vida = vida;
        this.interfazGrafica = ui;
    }

    internal void AumentarDificultadDeEnemigo()
    {
        VelocidadDeBajada *= AumentoDeVelocidad;
    }

    public void RestandoVidaAlEnemigoPorLaBalaQueLlega(IBalaPlayerShoot bala)
    {
        Vida -= bala.GetPoderDeBala();

        if (Vida <= 0)
        {
            enemigoGenericoMono.EsteEnemigoMuere();
            interfazGrafica.ActualizarPuntuacionGeneral(enemigoGenericoMono);
        }
    }

    public void ColisionParaSaberSiTieneQueMorir(bool colisionoConAlgoQueLoMata)
    {
        if (colisionoConAlgoQueLoMata)
        {
            enemigoGenericoMono.EsteEnemigoMuere();
        }
    }

    public void ColisionParaRestarVida(bool colisionoConAlgoQueLeHaceDaño, IBalaPlayerShoot balaPlayerShoot)
    {
        if (colisionoConAlgoQueLeHaceDaño)
        {
            RestandoVidaAlEnemigoPorLaBalaQueLlega(balaPlayerShoot);
        }
    }
}
public class LogicaDelMenuDePausa
{
    public bool TerminoLaAnimacion { get; set; }
    public bool VolverAlInicio { get; set; }
    public bool ReiniciarNivel { get; set; }
    public bool EsElOpening { get; set; }
    public float DeltaTimeLocal { get; set; }
    public double DuracionDePLayabe { get; set; }
    public bool MostrarTexto { get; set; }

    private ILogicaDeMenuDePausa logicaMono;

    public LogicaDelMenuDePausa(ILogicaDeMenuDePausa logica)
    {
        TerminoLaAnimacion = true;
        MostrarTexto = true;
        EsElOpening = true;
        logicaMono = logica;
    }


    public void AccionBotonReinicarNivel()
    {
        if (TerminoLaAnimacion)
        {
            logicaMono.Ending();
            ReiniciarNivel = true;
        }
    }

    public void AccionBotonSalir()
    {
        if (TerminoLaAnimacion)
        {
            logicaMono.Ending();
            VolverAlInicio = true;
        }
    }

    public void AccionBotonContinuar()
    {
        if (TerminoLaAnimacion)
        {
            logicaMono.Ending();
        }
    }

    public void EntreOpeningAndEndingQueDebeEjecutar(bool presionoBoton)
    {
        if (presionoBoton && TerminoLaAnimacion)
        {
            if (EsElOpening)
            {
                logicaMono.Opening();
            }
            else
            {
                logicaMono.Ending();
            }
        }
    }

    public void ControlandoAccionesQueDebenDeDarseDuranteElJuego(float deltaTimeOriginal)
    {
        if (!TerminoLaAnimacion)
        {
            DeltaTimeLocal += deltaTimeOriginal;
            var yaPasoEltiempoDeLaAnimacion = DeltaTimeLocal >= DuracionDePLayabe;
            if (yaPasoEltiempoDeLaAnimacion)
            {
                DeltaTimeLocal = 0;
                TerminoLaAnimacion = true;
                logicaMono.LimpiarDirector();
                DuracionDePLayabe = 0;
                if (EsElOpening)
                {
                    logicaMono.OcultarPanel();
                    MostrarTexto = false;
                    if (ReiniciarNivel)
                    {
                        ReiniciarNivel = false;
                        logicaMono.ReinciarLaEscenaActual();
                    }
                    if (VolverAlInicio)
                    {
                        VolverAlInicio = false;
                        logicaMono.CargarLaPrimeraEscena();
                    }
                }
                else
                {
                    MostrarTexto = true;
                }
            }
        }
    }

}

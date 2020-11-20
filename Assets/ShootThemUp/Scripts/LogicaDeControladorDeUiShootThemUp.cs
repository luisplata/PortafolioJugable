using System;

public class LogicaDeControladorDeUiShootThemUp
{
    private IControlDorDeUiShotThemUp controlDorDeUiShotThemUp;
    public int PuntuacionGeneralInt { get; set; }
    public int CantidadObrerosInt { get; set; }
    public int CantidadGeneralint { get; set; }
    public int CantidadCapitanint { get; set; }
    public int CantidadRaroInt { get; set; }

    public LogicaDeControladorDeUiShootThemUp(IControlDorDeUiShotThemUp controlDorDeUiShotThemUp)
    {
        this.controlDorDeUiShotThemUp = controlDorDeUiShotThemUp;
        ActualziarPuntuacion();
    }

    public void ActualziarPuntuacion()
    {
        controlDorDeUiShotThemUp.PuntuacionInicial(PuntuacionGeneralInt, CantidadObrerosInt, CantidadGeneralint, CantidadGeneralint, CantidadRaroInt);
    }

    public void ActualziarPuntuacionConEnemigoEspecifico(IEnemigoGenericoMono enemigo)
    {
        if (typeof(EnemigoObrero).Equals(enemigo.GetType()))
        {
            CantidadObrerosInt++;
        }
        else if (typeof(EnemigoCapitan).Equals(enemigo.GetType()))
        {
            CantidadCapitanint++;
        }
        else if (typeof(EnemigoGeneralPrimero).Equals(enemigo.GetType()))
        {
            CantidadGeneralint++;
        }
        else if (typeof(EnemigoRaro).Equals(enemigo.GetType()))
        {
            CantidadRaroInt++;
        }

        PuntuacionGeneralInt += enemigo.GetPuntuacion();

        ActualziarPuntuacion();
    }
}
using System;

public class LogicaCofreFinal
{
    private IConfreFinalMono confreFinalMono;

    public LogicaCofreFinal(IConfreFinalMono confreFinalMono)
    {
        this.confreFinalMono = confreFinalMono;
    }

    public void ElPlayerTocoElCofre(bool esElPlayerChocando)
    {
        if (esElPlayerChocando)
        {
            confreFinalMono.LlamarAnimacionDeApertura();
        }
    }
}
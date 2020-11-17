public class LogicaDeBloquesDestructibles
{
    BloqueDestructibleGenerico logicaMono;
    public LogicaDeBloquesDestructibles(BloqueDestructibleGenerico mono)
    {
        logicaMono = mono;
    }

    public void CuandoElPlayerNosPegaConLaCabeza(bool esLaCabeza)
    {
        if (esLaCabeza)
        {
            logicaMono.CuandoLePeganAlBloque();
        }
    }
}
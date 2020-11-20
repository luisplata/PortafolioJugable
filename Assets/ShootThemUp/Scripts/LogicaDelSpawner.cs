using System.Collections.Generic;

public class LogicaDelSpawner
{

    public float TiempoDeSpawn { get; set; }
    public float DeltaTimeLocal { get; set; }
    public IFactoryaDeEnemigos Factoria { get; set; }

    private ISpawnearEnemigos logicaMono;

    public LogicaDelSpawner(ISpawnearEnemigos spawnearEnemigos, float tiempoDeSpawn, List<EnemigoGeneral_shoot> listaEnemigos)
    {
        logicaMono= spawnearEnemigos;
        TiempoDeSpawn = tiempoDeSpawn;
        DeltaTimeLocal = tiempoDeSpawn - 1;
        Factoria = new FactoriaEnemigos(listaEnemigos);
    }

    public void EsTiempoDeSpawnear(float deltaTime)
    {
        DeltaTimeLocal += deltaTime;

        if (DeltaTimeLocal >= TiempoDeSpawn)
        {
            DeltaTimeLocal = 0;
            logicaMono.SpawnearEnemigo();
        }
    }


    public EnemigoGeneral_shoot InstanciarEnemigo()
    {
        //cual vamos a instanciar
        int probabilidad = logicaMono.RandomLocal(0,100);
        if (probabilidad >= 0 && probabilidad <= 10)
        {
            return Factoria.Create("raro");
        }
        if (probabilidad >= 10 && probabilidad <= 25)
        {
            return Factoria.Create("general");
        }
        if (probabilidad > 25 && probabilidad <= 50)
        {
            return Factoria.Create("capitan");
        }
        else
        {
            return Factoria.Create("obrero");
        }
    }
}
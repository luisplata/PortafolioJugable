using System.Collections.Generic;

public class FactoriaEnemigos : IFactoryaDeEnemigos
{
    public FactoriaEnemigos(List<EnemigoGeneral_shoot> enemigos)
    {
        DiccionarioEnemigos = new Dictionary<string, EnemigoGeneral_shoot>();
        foreach (EnemigoGeneral_shoot enemigo in enemigos)
        {
            DiccionarioEnemigos.Add(enemigo.Id, enemigo);
        }
    }

    public EnemigoGeneral_shoot Create(string id)
    {
        if (!DiccionarioEnemigos.TryGetValue(id, out var enemigo))
        {
            throw new EnemigoNoEncontradoException($"enemigo with id {id} does not exit");
        }
        return enemigo;
    }

    public Dictionary<string, EnemigoGeneral_shoot> DiccionarioEnemigos { get; private set; }
}
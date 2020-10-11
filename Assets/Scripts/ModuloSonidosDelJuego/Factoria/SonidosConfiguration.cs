using Assets.Scripts.ModuloSonidosDelJuego;
using Assets.Scripts.ModuloSonidosDelJuego.Exceptions;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StrikeNation/Sound/Weise/Config")]
public class SonidosConfiguration : ScriptableObject
{
    [SerializeField] private SonidoParaSonar[] sonidos;
    private Dictionary<EnumSonidosParaSonar, SonidoParaSonar> listaDeSonidos;

    private void Awake()
    {
        listaDeSonidos = new Dictionary<EnumSonidosParaSonar, SonidoParaSonar>(sonidos.Length);
        foreach (var sonido in sonidos)
        {
            listaDeSonidos.Add(sonido.Id, sonido);
        }
    }

    public SonidoParaSonar GetSonidoPrefabById(EnumSonidosParaSonar id)
    {
        if (!listaDeSonidos.TryGetValue(id, out var powerUp))
        {
            throw new SonidoNoEncontradoException($"Sonido with id {id} does not exit");
        }
        return powerUp;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class SpwnerDeEnemigos : MonoBehaviour, ISpawnearEnemigos
{
    [SerializeField] private List<EnemigoGeneral_shoot> listaEnemigos;
    [SerializeField] private float tiempoDeSpawn;
    [SerializeField] private int limiteIzquierda, limiteDerecha;

    private LogicaDelSpawner logica;

    private void Start()
    {
        logica = new LogicaDelSpawner(this, tiempoDeSpawn, listaEnemigos);
    }

    private void Update()
    {
        logica.EsTiempoDeSpawnear(Time.deltaTime);
    }

    public void SpawnearEnemigo()
    {
        GameObject enemigo = Instantiate(logica.InstanciarEnemigo()).gameObject;
        float x = RandomLocal(limiteIzquierda, limiteDerecha);
        enemigo.transform.position = new Vector2(x, transform.position.y);
    }

    public int RandomLocal(int v1, int v2) => Random.Range(v1, v2);
}
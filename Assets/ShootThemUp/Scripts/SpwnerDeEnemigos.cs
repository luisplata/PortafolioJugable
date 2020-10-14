
using UnityEngine;

public class SpwnerDeEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject obrero, capitan, general, raro;

    private float deltaTimeLocal;
    [SerializeField] private float tiempoDeSpawn;
    [SerializeField] private int limiteIzquierda, limiteDerecha;

    private void Start()
    {
        deltaTimeLocal = tiempoDeSpawn - 1;
    }
    private void Update()
    {
        if (EsTiempoDeSpawnear())
        {
            GameObject enemigo = Instantiate(InstanciarEnemigo());
            float x = Random.Range(limiteIzquierda, limiteDerecha);
            enemigo.transform.position = new Vector2(x, transform.position.y);
        }
    }

    private GameObject InstanciarEnemigo()
    {
        //cual vamos a instanciar
        int probabilidad = Random.Range(0, 100);
        Debug.Log(probabilidad);
        if(probabilidad >= 0 && probabilidad <= 10)
        {
            return raro;
        }
        if (probabilidad >= 10 && probabilidad <= 25)
        {
            return general;
        }
        if (probabilidad >= 35 && probabilidad <= 50)
        {
            return capitan;
        }
        else
        {
            return general;
        }
    }

    private bool EsTiempoDeSpawnear()
    {
        bool resultado = false;

        deltaTimeLocal += Time.deltaTime;

        if(deltaTimeLocal >= tiempoDeSpawn)
        {
            deltaTimeLocal = 0;
            resultado = true;
        }

        return resultado;
    }
}
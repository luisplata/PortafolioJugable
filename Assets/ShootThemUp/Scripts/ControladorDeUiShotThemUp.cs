using UnityEngine;
using TMPro;

public class ControladorDeUiShotThemUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI candidadObrero, cantidadGeneral, cantidadCapitan, cantidadRaro, puntuacionGeneral, temporalizador;
    private int puntuacionGeneralInt, cantidadObrerosInt, cantidadGeneralint, cantidadCapitanint, cantidadRaroInt;
    [SerializeField] private float temporalizadorFloat;//Este debe tener el tiempo limite en segundos
    private bool segirContando = true;

    private void Start()
    {
        ActualziarPuntuacion();
    }

    private void ActualziarPuntuacion()
    {
        puntuacionGeneral.text = puntuacionGeneralInt.ToString();
        candidadObrero.text = cantidadObrerosInt.ToString();
        cantidadCapitan.text = cantidadCapitanint.ToString();
        cantidadGeneral.text = cantidadGeneralint.ToString();
        cantidadRaro.text = cantidadRaroInt.ToString();
    }

    public void ActualizarPuntuacionGeneral(EnemigoGeneral_shoot enemigo)
    {
        if (typeof(EnemigoObrero).Equals(enemigo.GetType()))
        {
            cantidadObrerosInt++;
        }else if (typeof(EnemigoCapitan).Equals(enemigo.GetType()))
        {
            cantidadCapitanint++;
        }
        else if (typeof(EnemigoGeneralPrimero).Equals(enemigo.GetType()))
        {
            cantidadGeneralint++;
        }
        else if (typeof(EnemigoRaro).Equals(enemigo.GetType()))
        {
            cantidadRaroInt++;
        }

        puntuacionGeneralInt += enemigo.GetPuntuacion();

        ActualziarPuntuacion();
    }

    public void TerminoElTiempo()
    {

    }

    private void Update()
    {
        if(segirContando) temporalizadorFloat -= Time.deltaTime;

        int minutos = 0;
        int segundos = 0;
        int milisegundos = 0;
        if (temporalizadorFloat <= 0)
        {
            segirContando = false;
            TerminoElTiempo();
        }
        else
        {
            minutos = (int)(temporalizadorFloat / 60);
            segundos = (int)(temporalizadorFloat % 60);
            milisegundos = (int)((temporalizadorFloat - minutos - segundos) * 1000);
        }

        temporalizador.text = string.Format("{0}:{1}:{2}",minutos, segundos, milisegundos);
    }
}
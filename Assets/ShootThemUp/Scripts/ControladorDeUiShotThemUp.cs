using UnityEngine;
using TMPro;

public class ControladorDeUiShotThemUp : MonoBehaviour, IControlDorDeUiShotThemUp
{
    [SerializeField] private TextMeshProUGUI candidadObrero;
    [SerializeField] private TextMeshProUGUI cantidadGeneral;
    [SerializeField] private TextMeshProUGUI cantidadCapitan;
    [SerializeField] private TextMeshProUGUI cantidadRaro;
    [SerializeField] private TextMeshProUGUI puntuacionGeneral;
    [SerializeField] private TextMeshProUGUI temporalizador;
    [SerializeField] private float temporalizadorFloat;//Este debe tener el tiempo limite en segundos
    private bool segirContando = true;
    private LogicaDeControladorDeUiShootThemUp logica;

    private void Start()
    {
        logica = new LogicaDeControladorDeUiShootThemUp(this);
    }

    public void ActualizarPuntuacionGeneral(IEnemigoGenericoMono enemigo)
    {
        logica.ActualziarPuntuacionConEnemigoEspecifico(enemigo);
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

    public void PuntuacionInicial(int puntuacionGeneral, 
        int cantidadObreros, 
        int cantidadCaputan, 
        int cantidadGenral, 
        int cantidadRaro)
    {
        this.puntuacionGeneral.text = puntuacionGeneral.ToString();
        this.candidadObrero.text = cantidadObreros.ToString();
        this.cantidadCapitan.text = cantidadCaputan.ToString();
        this.cantidadGeneral.text = cantidadGenral.ToString();
        this.cantidadRaro.text = cantidadRaro.ToString();
    }
}
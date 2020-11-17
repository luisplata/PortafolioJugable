using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDeMenuDePausa : MonoBehaviour , ILogicaDeMenuDePausa
{
    [SerializeField] GameObject panel;
    [SerializeField] InputManager inputManager;
    [SerializeField] private PlayableAsset opening;
    [SerializeField] private PlayableAsset ending;
    [SerializeField] TextMeshProUGUI texto;
    private PlayableDirector director;
    [SerializeField] string dialogoDelMenu;
    [SerializeField] Button botonSalir, botonContinuar, botonReiniciarNivel;
    private LogicaDelMenuDePausa logicaLocal;

    private void Start()
    {
        logicaLocal = new LogicaDelMenuDePausa(this);

        director = panel.GetComponent<PlayableDirector>();
        botonContinuar.onClick.AddListener(delegate { logicaLocal.AccionBotonContinuar(); });
        botonSalir.onClick.AddListener(delegate { logicaLocal.AccionBotonSalir(); });
        botonReiniciarNivel.onClick.AddListener(delegate { logicaLocal.AccionBotonReinicarNivel(); });
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        logicaLocal.EntreOpeningAndEndingQueDebeEjecutar(inputManager.SeprecionoElBoton(InputDefinidosParaElJuego.Start));

        logicaLocal.ControlandoAccionesQueDebenDeDarseDuranteElJuego(Time.deltaTime);

        ColocandoTextoEnPantallaSiEsNecesario(logicaLocal.MostrarTexto);
    }

    public void CargarLaPrimeraEscena()
    {
        SceneManager.LoadScene(ServiceLocator.Instance.GetService<IConvertidorDeEnumToInt>().ConvertEnumToInt(EscenasDelJuego.INICIO));
    }

    public void ReinciarLaEscenaActual()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OcultarPanel()
    {
        panel.SetActive(false);
    }

    public void LimpiarDirector()
    {
        director.playableAsset = null;
    }

    public void ColocandoTextoEnPantallaSiEsNecesario(bool debeMostrarElTexto)
    {
        if (debeMostrarElTexto)
        {
            ColocarTextoEnPantalla(dialogoDelMenu, texto);
        }
    }

    public void Opening()
    {
        texto.text = "";
        panel.SetActive(true);
        logicaLocal.EsElOpening = false;
        logicaLocal.TerminoLaAnimacion = false;
        director.playableAsset = opening;
        director.Play();
        logicaLocal.DuracionDePLayabe = director.duration;
    }

    public void Ending()
    {
        logicaLocal.EsElOpening = true;
        logicaLocal.TerminoLaAnimacion = false;
        panel.SetActive(true);
        director.playableAsset = ending;
        director.Play();
        logicaLocal.DuracionDePLayabe = director.duration;

    }

    private void ColocarTextoEnPantalla(string texto, TextMeshProUGUI caja)
    {
        if (caja.text.Length < texto.Length)
            caja.text = texto.Substring(0, caja.text.Length + 1);
    }

}

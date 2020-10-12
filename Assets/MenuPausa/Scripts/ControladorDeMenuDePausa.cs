using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDeMenuDePausa : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] InputManager inputManager;
    [SerializeField] PlayableAsset opening, ending;
    [SerializeField] TextMeshProUGUI texto;
    private PlayableDirector director;
    [SerializeField] private bool terminoLaAnimacion = true;
    [SerializeField] private float deltaTimeLocal;
    private double duracionDePLayabe;
    private bool esElOpening = true;
    [SerializeField] string dialogoDelMenu;
    private bool mostrarTexto;
    [SerializeField] Button botonSalir, botonContinuar, botonReiniciarNivel;
    private bool reiniciarNivel;
    private bool volverAlInicio;

    private void Start()
    {
        director = panel.GetComponent<PlayableDirector>();
        botonContinuar.onClick.AddListener(delegate { AccionBotonContinuar(); });
        botonSalir.onClick.AddListener(delegate { AccionBotonSalir(); });
        botonReiniciarNivel.onClick.AddListener(delegate { AccionBotonReinicarNivel(); });
        DontDestroyOnLoad(gameObject);
    }

    private void AccionBotonSalir()
    {
        if (terminoLaAnimacion)
        {
            Ending();
            volverAlInicio = true;
        }
    }

    private void AccionBotonContinuar()
    {
        if (terminoLaAnimacion)
        {
            Ending();
        }
    }

    private void AccionBotonReinicarNivel()
    {
        if (terminoLaAnimacion)
        {
            Ending();
            reiniciarNivel = true;
        }
    }

    private void Update()
    {
        if (inputManager.SeprecionoElBoton(InputDefinidosParaElJuego.Start) && terminoLaAnimacion)
        {
            if (esElOpening)
            {
                Opening();
            }
            else
            {
                Ending();
            }
        }
        if (!terminoLaAnimacion)
        {
            deltaTimeLocal += Time.deltaTime;
            if(deltaTimeLocal >= duracionDePLayabe)
            {
                deltaTimeLocal = 0;
                terminoLaAnimacion = true;
                director.playableAsset = null;
                duracionDePLayabe = 0;
                if (esElOpening)
                {
                    panel.SetActive(false);
                    mostrarTexto = false;
                    if (reiniciarNivel)
                    {
                        reiniciarNivel = false;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                    if (volverAlInicio)
                    {
                        volverAlInicio = false;
                        SceneManager.LoadScene((int)EscenasDelJuego.NOVELAVISUAL);
                    }
                }
                else
                {
                    mostrarTexto = true;
                }
            }
        }

        if (mostrarTexto)
        {
            ColocarTextoEnPantalla(dialogoDelMenu, texto);
        }
    }

    private void Opening()
    {
        texto.text = "";
        panel.SetActive(true);
        esElOpening = false;
        terminoLaAnimacion = false;
        director.playableAsset = opening;
        director.Play();
        duracionDePLayabe = director.duration;
    }

    private void Ending()
    {
        esElOpening = true;
        terminoLaAnimacion = false;
        panel.SetActive(true);
        director.playableAsset = ending;
        director.Play();
        duracionDePLayabe = director.duration;

    }

    private void ColocarTextoEnPantalla(string texto, TextMeshProUGUI caja)
    {
        if (caja.text.Length < texto.Length)
            caja.text = texto.Substring(0, caja.text.Length + 1);
    }

}

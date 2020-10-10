using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ControladorDeEscenaNovelaVisual : MonoBehaviour
{
    public GameObject panelOpciones, opcion1, opcion2, opcion3;

    public Button botonSiguiente, botonSiguienteGO;

    public TextMeshProUGUI texto;

    [SerializeField] private PlayableDirector director;
    private double duracionDeAnimacion;
    private float deltaTimeLocal;
    private bool entroCreando = true;

    private void Start()
    {
        duracionDeAnimacion = director.duration;
    }

    private void Update()
    {
        deltaTimeLocal += Time.deltaTime;
        if(deltaTimeLocal >= duracionDeAnimacion && entroCreando)
        {
            gameObject.AddComponent(typeof(Dialogo_00));
            entroCreando = false;
        }
    }

}

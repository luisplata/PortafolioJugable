using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeEscenaNovelaVisual : MonoBehaviour
{
    public GameObject panelOpciones, opcion1, opcion2, botonSiguienteGO;

    public Button botonSiguiente;

    public TextMeshProUGUI texto;

    private void Start()
    {
        botonSiguiente = botonSiguienteGO.GetComponent<Button>();
    }
}

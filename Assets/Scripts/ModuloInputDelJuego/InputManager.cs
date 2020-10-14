using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private List<InputGame> listaDeIputs;
    private Dictionary<InputDefinidosParaElJuego, InputGame> diccionarioDeControles;
    public bool isJoitick;
    [SerializeField] string axisHorizontal, axisVertical;

    private void Awake()
    {
        diccionarioDeControles = new Dictionary<InputDefinidosParaElJuego, InputGame>();
        foreach (InputGame ig in listaDeIputs)
        {
            diccionarioDeControles.Add(ig.Id, ig);
        }
    }

    public string CambiarJoistickTeclado()
    {
        isJoitick = !isJoitick;
        string text;
        if (isJoitick)
        {
            text = "Se Juega con Control";
        }
        else
        {
            text = "Se Juega con Teclado";
        }
        text += " preciona para cambiar";

        return text;
    }

    public bool SeprecionoElBoton(InputDefinidosParaElJuego input)
    {
        InputGame ig;
        diccionarioDeControles.TryGetValue(input, out ig);
        if (isJoitick)
        {
            return Input.GetKeyDown(ig.Joistick);
        }
        else
        {
            return Input.GetKeyDown(ig.Keyboard);
        }
    }

    public KeyCode BotonPrecionado(InputDefinidosParaElJuego input)
    {
        InputGame ig;
        diccionarioDeControles.TryGetValue(input, out ig);
        if (isJoitick)
        {
            return ig.Joistick;
        }
        else
        {
            return ig.Keyboard;
        }
    }

    public float SeMovioHorizontalmente(int playerNumber)
    {
        return Input.GetAxis(axisHorizontal + ConstruirNombreDeAxis(playerNumber));
    }

    public float SeMovioHorizontalmente()
    {
        return Input.GetAxis(axisHorizontal + ConstruirNombreDeAxis());
    }

    public float SeMovioVerticalmente(int playerNumber)
    {
        return Input.GetAxis(axisVertical+ ConstruirNombreDeAxis(playerNumber));
    }
    public float SeMovioVerticalmente()
    {
        return Input.GetAxis(axisVertical + ConstruirNombreDeAxis());
    }

    private string ConstruirNombreDeAxis()
    {
        string nombreBase = "";
        nombreBase += isJoitick ? "_joi" : "_key";
        return nombreBase;
    }

    private string ConstruirNombreDeAxis(int playerNumber)
    {
        string nombreBase = "";
        nombreBase += isJoitick ? "_joi" : "_key";
        nombreBase += playerNumber.ToString();
        return nombreBase;
    }
}

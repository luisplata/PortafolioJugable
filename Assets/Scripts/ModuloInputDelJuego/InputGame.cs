using UnityEngine;
public class InputGame : MonoBehaviour
{
    [SerializeField]private KeyCode keyboard;
    [SerializeField] private KeyCode joistick;
    [SerializeField] private InputDefinidosParaElJuego id;

    public InputDefinidosParaElJuego Id => id;
    public KeyCode Keyboard => keyboard;
    public KeyCode Joistick => joistick;
}
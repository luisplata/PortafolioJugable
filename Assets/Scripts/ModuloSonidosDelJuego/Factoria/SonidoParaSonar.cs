using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoParaSonar : MonoBehaviour
{
    [SerializeField]private EnumSonidosParaSonar id;
    [SerializeField] private object evento;

    public EnumSonidosParaSonar Id => id;
    public object Evento => evento; 
}

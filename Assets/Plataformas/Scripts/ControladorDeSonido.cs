using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonido : MonoBehaviour
{
    public List<AudioClip> libreriaDeSonidos;
    public AudioSource source;

    public void EjecutarSonido(string nombre)
    {
        foreach (AudioClip audio in libreriaDeSonidos)
        {
            if (audio.name == nombre)
            {
                source.PlayOneShot(audio);
            }
        }
    }
}
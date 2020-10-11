using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.ModuloSonidosDelJuego.Exceptions
{
    public class SonidoNoEncontradoException : Exception
    {
        public SonidoNoEncontradoException()
        {
        }

        public SonidoNoEncontradoException(string message)
            : base(message)
        {
        }

        public SonidoNoEncontradoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
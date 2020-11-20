using System;
using System.Runtime.Serialization;

[Serializable]
internal class EnemigoNoEncontradoException : Exception
{
    public EnemigoNoEncontradoException()
    {
    }

    public EnemigoNoEncontradoException(string message) : base(message)
    {
    }

    public EnemigoNoEncontradoException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected EnemigoNoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
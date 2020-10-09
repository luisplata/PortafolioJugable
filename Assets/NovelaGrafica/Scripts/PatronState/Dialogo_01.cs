using System;

public class Dialogo_01 : AccionTextoNormal
{
    public override void Start()
    {
        base.Start();
        dialogo = "No te preocupes por perder el juego o tomar malas desiciones, al final este no es la vida real.";
    }

    public override void Salir()
    {
        
    }

    public override void Update()
    {
        VerificarCambios();
        ColocarTextoEnPantalla(dialogo, controlador.texto);
    }

    public override Type VerficarTransiciones()
    {
        if (finalizoAccion)
        {
            return typeof(Dialogo_02);
        }
        return GetType();
    }
}

using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Dialogo_02 : AccionDeOpciones
{
    public override void Start()
    {
        base.Start();
        dialogo = "Ahora, cuentame que quieres hacer?";
        opciones = new List<string>
        {
            "Conocerme mejor. (Plataformas)",
            "Información academica. (Shoot them up)",
            "Ver mi experiencia laboral. (N/A)"
        };
    }

    public override void Salir()
    {
        NormalizamosTextos();
    }

    public override void Update()
    {
        ColocarTextoEnPantalla(dialogo, controlador.texto);
        VerificarCambios();
        if (finalizoAccion)
        {
            ColocarOpcionesEnPantlla(opciones);
            finalizoAccion = false;
        }
    }

    public override Type VerficarTransiciones()
    {
        if (pasarAlSiguienteDialogo)
        {
            return GetType();
        }
        return GetType();
    }

    public override void Opcion1()
    {
        CargarEscena((int)EscenasDelJuego.PLATAFORMAS);
    }

    private void CargarEscena(int escena)
    {
        //hay que correr un timeline para posteriormente cambiar
        //por ahora esto
        SceneManager.LoadScene(escena);
    }

    public override void Opcion2()
    {
        CargarEscena((int)EscenasDelJuego.SHOOTTHEMUP);
    }

    public override void Opcion3()
    {
        
    }
}

using UnityEngine;

public abstract class BloqueDestructibleGenerico : MonoBehaviour
{
    protected ControladorDeSonido controladorDeSonido;
    protected Animator animador;
    protected SpriteRenderer sprite;

    protected void Start()
    {
        sprite = transform.Find("GameObject").GetComponent<SpriteRenderer>();
        controladorDeSonido = GameObject.Find("SFX").GetComponent<ControladorDeSonido>();
        animador = GetComponent<Animator>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cabeza"))
        {
            CuandoLePeganAlBloque();
        }
    }

    protected abstract void CuandoLePeganAlBloque();

    protected abstract void SeTerminoLaAnimacion();
}

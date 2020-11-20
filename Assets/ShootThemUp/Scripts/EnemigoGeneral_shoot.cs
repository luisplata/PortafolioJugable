using UnityEngine;

public abstract class EnemigoGeneral_shoot : MonoBehaviour, IEnemigoGenericoMono
{
    [SerializeField] protected float velocidadDeBajada;
    [SerializeField] protected float aumentoDeVelocidad;
    [SerializeField] protected int vida;
    [SerializeField] private string id;
    protected Rigidbody2D rb;
    protected Animator anim;
    protected LogicaDeEnemigoGenerico logica;

    public string Id { get => id; set => id = value; }

    public void AumentarDificultad()
    {
        logica.AumentarDificultadDeEnemigo();
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        logica = new LogicaDeEnemigoGenerico(this, 
            GameObject.Find("Canvas").GetComponent<ControladorDeUiShotThemUp>(), 
            velocidadDeBajada, 
            aumentoDeVelocidad, 
            vida);
    }

    public abstract int GetPuntuacion();

    protected abstract Vector2 MovimientoHaciaAbajo();

    protected void Update()
    {
        rb.velocity = MovimientoHaciaAbajo();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        logica.ColisionParaRestarVida(collision.gameObject.CompareTag("balaPlayer"), collision.gameObject.GetComponent<IBalaPlayerShoot>());
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        logica.ColisionParaSaberSiTieneQueMorir(collision.gameObject.CompareTag("pared"));
    }

    public void EsteEnemigoMuere()
    {
        anim.SetTrigger("murio");
    }

    public void TerminoDeMorir()
    {
        Destroy(gameObject);
    }

    public void TieneQueMorir()
    {
        TerminoDeMorir();
    }
}

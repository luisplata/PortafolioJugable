using UnityEngine;

public abstract class BalaPlayerShoot : MonoBehaviour, IBalaPlayerShoot
{
    [SerializeField] protected int poder;
    [SerializeField] private float velocidadDeDisparo;
    private Rigidbody2D rb;
    private Animator anim;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public int GetPoderDeBala()
    {
        return poder;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo") || collision.gameObject.CompareTag("pared"))
        {
            velocidadDeDisparo = 0;
            anim.SetTrigger("exploto");
        }
    }

    protected virtual void Update()
    {
        rb.velocity = Vector2.up * (velocidadDeDisparo * Time.deltaTime);
    }

    private void TerminoLaAnimacionDeColision()
    {
        Destroy(gameObject);
    }
}
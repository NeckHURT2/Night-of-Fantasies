using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControle : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 10f;
    bool Parede = false;

    public Rigidbody2D rb;
    public Vector2 movimento;
    public bool noChao = false;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    void OnMove(InputValue value)
    {
        movimento = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (noChao)
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
    }

    void OnAttack()
    {
        Collider2D[] atingidos = Physics2D.OverlapCircleAll(
        transform.position + transform.right * 5f, 0.5f);

        foreach (Collider2D col in atingidos)
        {
            Debug.Log("Achou: " + col.gameObject.name + " | Tag: " + col.gameObject.tag);

            if (col.CompareTag("Inimigo"))
            {
                col.GetComponent<Inimigo>().ReceberDano(5);
            }
        }
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Chao"))
            noChao = true;
        
         if (colisao.gameObject.CompareTag("Parede"))
        {
            Parede = true;
        }
    }

     void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Chao"))
            noChao = false;
        
       if (colisao.gameObject.CompareTag("Parede"))
        {
            Parede = false;
        }
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(movimento.x * velocidade, rb.linearVelocity.y);
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Clicou!");
        }
    }
    void FixedUpdate()
    {
       // Vira o sprite automaticamente
        if (movimento.x != 0)
        {
           sr.flipX = movimento.x < 0;
        }
        
        if (Parede)
        {
            rb.linearVelocity = new Vector2( rb.linearVelocity.x,0);
        }
    }
    

}

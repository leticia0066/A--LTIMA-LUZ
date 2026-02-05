using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 7f;

    [Header("Sons")]
    public AudioClip somPulo;
    public AudioClip somPasso;

    [Header("Referências")]
    public Transform corpo;

    [Header("Lanterna")]
    public bool temLanterna = false;

    private Rigidbody2D rb;
    private bool noChao = true;
    private AudioSource audioSource;
    private bool tocandoPassos = false;
    private Vector3 escalaCorreta;

    // 🔹 ANIMAÇÃO (ADICIONADO)
    private Animator animator;

    void Start()
    {
        escalaCorreta = corpo.localScale;
    }
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // 🔹 pega o Animator (ADICIONADO)
        animator = GetComponentInChildren<Animator>();

        escalaCorreta = corpo.localScale;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Movimentar(horizontal);
        Pular();
        Virar(horizontal);
        SonsDePassos(horizontal);

        // 🔹 animação de andar / idle (ADICIONADO)
        animator.SetFloat("velocidade", Mathf.Abs(horizontal));
        animator.SetBool("noChao", noChao);

        corpo.localScale = new Vector3(Mathf.Sign(corpo.localScale.x) * Mathf.Abs(escalaCorreta.x),escalaCorreta.y,escalaCorreta.z);
    }

    void Movimentar(float h)
    {
        rb.linearVelocity = new Vector2(h * velocidade, rb.linearVelocity.y);
    }

    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            noChao = false;

            if (somPulo != null)
                audioSource.PlayOneShot(somPulo);

            // 🔹 animação de pulo (ADICIONADO)
            animator.SetTrigger("pulo");
        }
    }

    // não muda lógica
    void Virar(float h)
    {
        if (h == 0) return;

        SpriteRenderer sr = corpo.GetComponent<SpriteRenderer>();
        sr.flipX = h < 0;
    }

    void SonsDePassos(float h)
    {
        if (Mathf.Abs(h) > 0.1f && noChao)
        {
            if (!tocandoPassos)
            {
                audioSource.loop = true;
                audioSource.clip = somPasso;
                audioSource.Play();
                tocandoPassos = true;
            }
        }
        else
        {
            if (tocandoPassos)
            {
                audioSource.Stop();
                tocandoPassos = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chao"))
            noChao = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lanterna"))
        {
            temLanterna = true;
            Destroy(other.gameObject);
            Debug.Log("Lanterna coletada!");
        }
    }
}
                 
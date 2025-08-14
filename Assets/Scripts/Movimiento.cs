using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5.0f, salto = 10f;

    private float movimiento = 0f;
    private Rigidbody2D rb;
    [SerializeField] ParticleSystem particulas;
    private AudioSource efectoSonido;
    private bool enSuelo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        efectoSonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2 (movimiento * velocidad, rb.linearVelocity.y);

        //Salto
        if(Input.GetKeyDown(KeyCode.UpArrow) && enSuelo)
        {
            rb.AddForce(new Vector2(0,salto), ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }

        int escenaActual = SceneManager.GetActiveScene().buildIndex;

        if (escenaActual == 2) // Nivel 1
        {

            if (Cronometro.tiempo >= 60f)
            {
                SceneManager.LoadScene(5);
            }

            if (GameObject.FindGameObjectsWithTag("Pelota").Length == 0 && Cronometro.tiempo < 60f)
            {
                Cronometro.tiempoNivel1 = Cronometro.tiempo;
                Cronometro.nivelesCompletados = 1;
                SceneManager.LoadScene(3); // Nivel 2
            }            
        }
        else if (escenaActual == 3) // Nivel 2
        {
            if (Cronometro.tiempo >= 60f)
            {
                SceneManager.LoadScene(5); 
            }

            if (GameObject.FindGameObjectsWithTag("Pelota").Length == 0 && Cronometro.tiempo < 60f)
            {
                Cronometro.tiempoNivel2 = Cronometro.tiempo;
                Cronometro.nivelesCompletados = 2;
                SceneManager.LoadScene(4); 
            }
        }

        else if (escenaActual == 4) // Nivel 3
        {
            if (Cronometro.tiempo >= 60f)
            {
                SceneManager.LoadScene(5);
            }

            if (GameObject.FindGameObjectsWithTag("Pelota").Length == 0 && Cronometro.tiempo < 60f)
            {
                Cronometro.tiempoNivel2 = Cronometro.tiempo;
                Cronometro.nivelesCompletados = 3;
                SceneManager.LoadScene(5);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D objeto)
    {
        if(objeto.gameObject.tag == "Pelota")
        {
            var main = particulas.main;
            main.startColor = objeto.gameObject.GetComponent<SpriteRenderer>().color;
            particulas.Play();
            efectoSonido.Play();
        }
        //Cuando el jugador toca suelo, activo salto
        if(objeto.gameObject.CompareTag("Suelo")) enSuelo=true;
    }

    void OnCollisionExit2D(Collision2D objeto)
    {
        //Cuando esta en el aire desactivo salto
        if(objeto.gameObject.CompareTag("Suelo")) enSuelo = false;
    }
}

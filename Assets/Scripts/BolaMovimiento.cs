using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMovimiento : MonoBehaviour
{
    private AudioSource efectoSonido;
    public float initialSpeed = 6.0f;
    private float velocidadActual;
    private Rigidbody2D rb;
    private bool gameStarted = false;
    public GameObject particulas;
    public Transform vidasUIParent;
    private List<GameObject> vidasUI = new List<GameObject>();
    private int vidasRestantes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        efectoSonido = GetComponent<AudioSource>();
        velocidadActual = initialSpeed;

        // Llenar la lista con los hijos del objeto padre de las vidas
        foreach (Transform vida in vidasUIParent)
        {
            vidasUI.Add(vida.gameObject);
        }

        vidasRestantes = vidasUI.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted && Input.GetButtonDown("Fire1"))
        {
            LaunchBall();
            gameStarted = true;
        }
          
    }

    void FixedUpdate()
    {
        // Mantener velocidad constante mientras el juego esté en marcha
        if (gameStarted)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * velocidadActual;
        }
    }

    void LaunchBall()
    {
        // Lanzar la pelota hacia arriba y ligeramente a la derecha/izquierda
        rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * velocidadActual;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con un ladrillo
        if (collision.gameObject.CompareTag("Ladrillo"))
        {
            efectoSonido.Play();
            GameObject instanciaParticulas = Instantiate(particulas, collision.transform.position, Quaternion.identity);
            ParticleSystem ps = instanciaParticulas.GetComponent<ParticleSystem>();
            Color colorLadrillo = collision.gameObject.GetComponent<SpriteRenderer>().color;
            var main = ps.main;
            main.startColor = colorLadrillo;
            Destroy(collision.gameObject); // Destruye el ladrillo
            GameManager.instancia.SumarPuntos(10);
        }
        
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si choca con la zona de muerte (BottomDeathZone)
        if (other.CompareTag("Muerte"))
        {
            Debug.Log("Pelota perdida!");
            gameStarted = false; // Resetear para relanzar o perder vida

            // Aquí iría la lógica del GameManager para perder vida, reiniciar pelota, etc.
            if (vidasRestantes > 0)
            {
                vidasRestantes--;
                vidasUI[vidasRestantes].SetActive(false);
            }

            // Si ya no hay vidas, termina el juego
            if (vidasRestantes <= 0)
            {
                Debug.Log("¡Game Over!");
                gameObject.SetActive(false); // Desactiva la bola
                GameManager.instancia.CargarEscenaDerrota();
                return;
            }

            // Por ahora, solo la reseteamos a la posición inicial (para pruebas)
            transform.position = new Vector3(0, -4.9f, 0); // Posición inicial
            rb.linearVelocity = Vector2.zero; // Detener la pelota
        }
    }

    public void AumentarVelocidad()
    {
        velocidadActual += 1.0f;
        Debug.Log("Nueva velocidad: " + velocidadActual);
    }
}

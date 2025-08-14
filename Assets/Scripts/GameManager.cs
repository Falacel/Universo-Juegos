using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instancia;

    public int puntuacion = 0;
    public TextMeshProUGUI textoPuntuacion;

    public int puntosMaximos = 720;
    private int siguienteMeta = 100;

    public BolaMovimiento bola;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        ActualizarUI();

        // Aumentar velocidad cada 100 puntos
        if (puntuacion >= siguienteMeta)
        {
            siguienteMeta += 100;
            if (bola != null)
            {
                bola.AumentarVelocidad();
            }
        }

        // Verificar victoria
        if (puntuacion >= puntosMaximos)
        {
            CargarEscenaVictoria();
        }
    }

    void ActualizarUI()
    {
        if (textoPuntuacion != null)
            textoPuntuacion.text = "Score: " + puntuacion;
    }

    public void CargarEscenaDerrota()
    {
        SceneManager.LoadScene(9); 
    }

    public void CargarEscenaVictoria()
    {
        SceneManager.LoadScene(8); 
    }
}

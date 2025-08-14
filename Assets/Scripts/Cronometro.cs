using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cronometro : MonoBehaviour
{
    public static float tiempo;    
    public static float tiempoNivel1;
    public static float tiempoNivel2;
    public static int nivelesCompletados = 0;

    private TextMeshProUGUI contadorTexto;
   
    void Start()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;

        // Solo reinicia el contador si estás en niveles jugables
        if (escenaActual == 1 || escenaActual == 2 || escenaActual == 3)
        {
            tiempo = 0f;
        }

        contadorTexto = GameObject.Find("CronometroTexto").GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempo / 60F);
        int segundos = Mathf.FloorToInt(tiempo % 60F);
        int milisegundos = Mathf.FloorToInt((tiempo * 100) % 100F);
        contadorTexto.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }
}

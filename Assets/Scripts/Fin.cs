using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    private TextMeshProUGUI puntuacion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float total = Cronometro.tiempoNivel1 + Cronometro.tiempoNivel2;
        puntuacion = GameObject.Find("Puntuacion").GetComponent<TextMeshProUGUI>();
        puntuacion.text = "Niveles Completados: " + Cronometro.nivelesCompletados;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }


}

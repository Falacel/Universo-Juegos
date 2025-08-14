using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(2);
    }

    public void JugarRompemuros()
    {
        SceneManager.LoadScene(7);
    }

    public void SpaceShooter()
    {
        SceneManager.LoadScene(11);
    }


    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}

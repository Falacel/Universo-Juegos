using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void TrianguloSaltarin()
    {
        SceneManager.LoadScene(1);
    }
    public void RompemurosCosmico()
    {
        SceneManager.LoadScene(6);
    }

    public void SpaceShooter()
    {
        SceneManager.LoadScene(10);
    }

    public void Cerrar()
    {
        Application.Quit();
    }
}

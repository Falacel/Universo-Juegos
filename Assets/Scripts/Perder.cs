using UnityEngine;
using UnityEngine.SceneManagement;

public class Perder : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(6);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPaleta : MonoBehaviour
{
    public float velocidad = 10.0f;
    private float movimiento = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movimiento = Input.GetAxis("Horizontal");
        Vector2 nuevaPos = rb.position + Vector2.right * movimiento * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(nuevaPos);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(6);
        }

    }
}

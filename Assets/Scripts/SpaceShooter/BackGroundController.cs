using UnityEngine;

public class BackGroundController : MonoBehaviour
{

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }



}

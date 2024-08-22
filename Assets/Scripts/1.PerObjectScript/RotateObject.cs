using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float speed = 300;
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}

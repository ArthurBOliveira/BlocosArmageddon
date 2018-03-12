using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        Vector3 playerPos = new Vector3(Mathf.Clamp(xPos, -4.5f, 4.5f), -4.5f, 1f);
        transform.position = playerPos;
    }
}

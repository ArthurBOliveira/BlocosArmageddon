using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float xBorders;
    
    private Rigidbody2D rb2d;

    private float move;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xPos = transform.position.x + (move * speed);
        //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        Vector3 playerPos = new Vector3(Mathf.Clamp(xPos, xBorders * -1, xBorders), -4f, 1f);
        transform.position = playerPos;
    }

    public void Move(int x)
    {
        move = x;
    }

    public void Stop()
    {
        move = 0;
    }
}

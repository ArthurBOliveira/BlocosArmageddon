using UnityEngine;

public class Ball : MonoBehaviour
{
    public int damage;
    public float speed;
    public float maxSpeed;
    public Vector2 currSpeed;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        InitialKick();
    }

    private void Update()
    {
        //Limiting Speed;
        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

        if (rb2d.velocity.y > maxSpeed)
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed);

        if (rb2d.velocity.y < -maxSpeed)
            rb2d.velocity = new Vector2(rb2d.velocity.x, -maxSpeed);

        currSpeed = rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.collider.CompareTag("Player"))
        {
            Debug.Log("bateu");

            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            rb2d.velocity = dir * speed * 5;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Destructible"))
        {
            collision.gameObject.GetComponent<Destructible>().CauseDamage(damage);
        }
    }

    private float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket

        float result = ((ballPos.x - racketPos.x) / racketWidth) * 0.75f;

        return result;
    }

    public void InitialKick()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(1, 1) * speed);
    }
}
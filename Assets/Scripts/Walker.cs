using System.Collections;
using UnityEngine;

public class Walker : Destructible
{
    public float speed;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Walk());
    }

    private IEnumerator Walk()
    {
        while (true)
        {
            Vector2 direction;
            int rng = Random.Range(0, 3);

            switch (rng)
            {
                case 0:
                    direction = Vector2.left;
                    break;
                case 1:
                    direction = Vector2.up;
                    break;
                case 2:
                    direction = Vector2.right;
                    break;
                case 3:
                    direction = Vector2.down;
                    break;
                default:
                    direction = Vector2.up;
                    break;
            }

            rb2d.velocity = direction * speed;

            yield return new WaitForSeconds(2);
        }
    }
}

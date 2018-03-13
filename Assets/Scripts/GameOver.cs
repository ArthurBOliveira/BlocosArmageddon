using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameController gc;

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            gc.ResetBall();
        }
    }
}

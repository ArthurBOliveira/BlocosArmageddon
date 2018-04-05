using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int time;

    private GameController gc;

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gc.AddTime(time);
            Destroy(gameObject);
        }
    }
}

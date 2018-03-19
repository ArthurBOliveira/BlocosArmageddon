using UnityEngine;

public class GameController : MonoBehaviour
{
    // 0 - Indestructible; 1 - Block; 2 - LargeBlock; 3 - Walker; 
    public GameObject[] objects;
    public GameObject ballObject;

    private Ball ball;

    private void Awake()
    {
        ball = ballObject.GetComponent<Ball>();
    }

    private void Start()
    {
        //Indestructibles
        Instantiate(objects[0], new Vector3(5, 0), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-5, 0), Quaternion.identity);
        Instantiate(objects[0], new Vector3(5.64f, 0), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-5.64f, 0), Quaternion.identity);

        //Blocks
        for (int y = 1; y <= 4; y++)
            for (int x = -5; x <= 5; x++)
                Instantiate(objects[1], new Vector3(x, y), Quaternion.identity);
    }

    public void ResetBall()
    {
        ballObject.transform.position = new Vector3(0, -4);

        ball.InitialKick();
    }
}

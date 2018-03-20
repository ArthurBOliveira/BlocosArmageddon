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
        Instantiate(objects[0], new Vector3(2.75f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2.75f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(3.2f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-3.25f, -1), Quaternion.identity);

        //Blocks
        for (float y = 0; y <= 3.5f; y += 0.55f)
            for (float x = -2.75f; x <= 2.75f; x += 0.45f)
                Instantiate(objects[1], new Vector3(x, y), Quaternion.identity);
    }

    public void ResetBall()
    {
        ballObject.transform.position = new Vector3(0, -4);

        ball.InitialKick();
    }
}

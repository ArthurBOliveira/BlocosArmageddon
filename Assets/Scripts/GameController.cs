using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // 0 - Indestructible; 1 - Block; 2 - LargeBlock; 3 - Walker; 
    public GameObject[] objects;
    public GameObject ballObject;

    public Text txtTime;
    public Text txtCountDown;

    private Ball ball;
    private float time;

    private bool countingTime;

    #region Privates
    private void Awake()
    {
        ball = ballObject.GetComponent<Ball>();
    }

    private void Start()
    {
        time = 120;
        ball.gameObject.SetActive(false);
        countingTime = false;
        StartCoroutine(DelayedStart());
    }
    private void Update()
    {
        if (!countingTime) return;

        time -= Time.deltaTime;

        int min = (int)time / 60;
        int sec = (int)time % 60;

        txtTime.text = min + ":" + sec;
    }

    private IEnumerator DelayedStart()
    {
        txtCountDown.text = "3";
        yield return new WaitForSeconds(0.75f);
        txtCountDown.text = "2";
        yield return new WaitForSeconds(0.75f);
        txtCountDown.text = "1";
        yield return new WaitForSeconds(0.75f);
        txtCountDown.text = "Start!";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "";

        SpawnObjects();
        countingTime = true;
        ball.gameObject.SetActive(true);
        yield return new WaitForSeconds(0);
    }

    private void SpawnObjects()
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

    private void GameOver()
    {
        Destroy(ball);
    }
    #endregion

    #region Publics
    public void ResetBall()
    {
        ballObject.transform.position = new Vector3(0, -4);

        ball.InitialKick();
    }
    #endregion    
}

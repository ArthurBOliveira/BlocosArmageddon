using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // 0 - Indestructible; 1 - Block; 2 - LargeBlock; 3 - Walker; 
    public GameObject[] objects;
    public GameObject ballObject;

    public Text txtTime;
    public Text txtTimeChange;
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
        for (int framecnt = 0; framecnt < 30; framecnt++)
        {
            yield return new WaitForEndOfFrame();
            txtCountDown.fontSize -= 2;
        }
        txtCountDown.fontSize = 60;
        //yield return new WaitForSeconds(0.75f);

        txtCountDown.text = "2";
        for (int framecnt = 0; framecnt < 30; framecnt++)
        {
            yield return new WaitForEndOfFrame();
            txtCountDown.fontSize -= 2;
        }
        txtCountDown.fontSize = 60;
        //yield return new WaitForSeconds(0.75f);

        txtCountDown.text = "1";
        for (int framecnt = 0; framecnt < 30; framecnt++)
        {
            yield return new WaitForEndOfFrame();
            txtCountDown.fontSize -= 2;
        }
        txtCountDown.fontSize = 60;
        //yield return new WaitForSeconds(0.75f);

        txtCountDown.text = "Start!";
        yield return new WaitForSeconds(0.75f);
        txtCountDown.text = "";

        SpawnObjects();
        countingTime = true;
        ball.gameObject.SetActive(true);
        yield return new WaitForSeconds(0);
    }

    private void SpawnObjects()
    {
        //Indestructibles
        Instantiate(objects[0], new Vector3(2.0f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2.0f, -1), Quaternion.identity);
        //Instantiate(objects[0], new Vector3(3.2f, -1), Quaternion.identity);
        //Instantiate(objects[0], new Vector3(-3.25f, -1), Quaternion.identity);

        //Blocks
        for (float y = 0; y <= 3.5f; y += 0.55f)
            for (float x = -2.75f; x <= 2.75f; x += 0.45f)
                Instantiate(objects[1], new Vector3(x, y), Quaternion.identity);
    }

    private void GameOver()
    {
        Destroy(ball);
    }

    private IEnumerator TimeChangeAnimation(int change)
    {
        Debug.Log(change);

        txtTimeChange.text = change.ToString();
        for (int framecnt = 0; framecnt < 30; framecnt++)
        {
            yield return new WaitForSeconds(0.15f);
            txtTimeChange.fontSize -= 1;
            txtTimeChange.rectTransform.position = new Vector3(txtTimeChange.rectTransform.position.x + 2, -34);
        }
        txtTimeChange.fontSize = 30;
        txtTimeChange.rectTransform.position = new Vector3(127, -34);

        txtTimeChange.text = "";
    }
    #endregion

    #region Publics
    public void ResetBall()
    {
        ballObject.transform.position = new Vector3(0, -3.8f);

        time -= 5;

        //StartCoroutine(TimeChangeAnimation(-5));

        ball.InitialKick();
    }
    #endregion    
}

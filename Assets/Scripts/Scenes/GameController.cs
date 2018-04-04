using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // 0 - Indestructible; 1 - Block; 2 - LargeBlock; 3 - Walker; 
    public GameObject[] objects;
    public GameObject ballObject;
    public GameObject playerObject;
    public GameObject btnRestart;
    public GameObject btnContinue;
    public GameObject btnLeft;
    public GameObject btnRight;
    public GameObject btnStart;
    public GameObject btnTouchStart;
    public GameObject btnAccStart;

    public Text txtTime;
    public Text txtTimeChange;
    public Text txtCountDown;
    public Text txtScore;
    public Text txtScoreTime;

    public string currScene;
    public string nextScene;

    public float initTime;

    public int score;
    public int currObjects;

    private float time;
    private bool isCountingTime;

    private Ball ball;
    private Player player;

    private AudioSource music;

    #region Privates
    private void Awake()
    {
        ball = ballObject.GetComponent<Ball>();
        player = playerObject.GetComponent<Player>();
        music = GetComponent<AudioSource>();
    }

    private void Start()
    {
        btnContinue.SetActive(false);
        btnRestart.SetActive(false);
        time = initTime;
        ball.gameObject.SetActive(false);
        isCountingTime = false;
    }

    private void Update()
    {
        if (!isCountingTime) return;

        if (time <= 0)
            GameOver();

        if (currObjects <= 0)
            StartCoroutine(Win());

        time -= Time.deltaTime;

        int min = (int)time / 60;
        int sec = (int)time % 60;

        txtTime.text = min + ":" + sec;
    }

    private void GameOver()
    {
        ball.gameObject.SetActive(false);
        isCountingTime = false;
        txtCountDown.text = "Game Over";
        btnRestart.SetActive(true);
    }

    private IEnumerator Win()
    {
        ball.gameObject.SetActive(false);
        isCountingTime = false;
        txtCountDown.text = "You win!";
        txtScore.text = "Score: " + score;
        yield return new WaitForSeconds(0.75f);
        txtScoreTime.text = "+" + time.ToString("000");

        yield return new WaitForSeconds(0.75f);
        txtScoreTime.text = "";
        txtScore.text = "Score: " + (score + time).ToString("000");

        btnRestart.SetActive(true);
        btnContinue.SetActive(true);

        yield return new WaitForSeconds(0);
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
        isCountingTime = true;
        music.Play();
        ball.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        ball.InitialKick();
    }

    private IEnumerator TimeChangeAnimation(float change)
    {
        if(change > 0)
        {
            txtTimeChange.text = "+" + change.ToString();
            txtTimeChange.color = Color.green;
        }
        else
        {
            txtTimeChange.text = change.ToString();
            txtTimeChange.color = Color.red;
        }

        txtTimeChange.fontSize = 1;

        for (int framecnt = 0; framecnt < 25; framecnt++)
        {
            if (txtTimeChange.fontSize > 25) continue;

            yield return new WaitForEndOfFrame();
            txtTimeChange.fontSize += 5;
        }

        yield return new WaitForSeconds(1);

        txtTimeChange.text = "";
    }
    #endregion

    #region Publics
    public virtual void SpawnObjects()
    {

    }

    public void ResetBall()
    {
        ballObject.transform.position = new Vector3(0, -3.8f);

        AddTime(-5);

        ball.InitialKick();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currScene);
    }

    public void ChangeCurrObjects(int change, int points)
    {
        score += points;
        currObjects += change;
    }

    public void PauseResumeGame()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void PickGameType(int gType)
    {
        player.gType = (GameType)gType;

        if (gType == 0)
        {
            btnLeft.SetActive(true);
            btnRight.SetActive(true);
        }

        btnStart.SetActive(false);
        btnTouchStart.SetActive(false);
        btnAccStart.SetActive(false);

        StartCoroutine(DelayedStart());
    }

    public void AddTime(float addTime)
    {
        time += addTime;
        StartCoroutine(TimeChangeAnimation(addTime));
    }
    #endregion
}

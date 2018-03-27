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
    public GameObject btnBtnStart;
    public GameObject btnTouchStart;
    public GameObject btnAccStart;

    public Text txtTime;
    public Text txtTimeChange;
    public Text txtCountDown;
    public Text txtScore;
    public Text txtScoreTime;

    public string currScene;
    public string nextScene;

    public int score;

    private int currObjects;    
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
        time = 180;
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

    private void SpawnObjects()
    {
        //Indestructibles
        Instantiate(objects[0], new Vector3(2.0f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2.0f, -1), Quaternion.identity);

        //Blocks
        for (float y = 0; y <= 3.5f; y += 0.55f)
            for (float x = -2.75f; x <= 2.75f; x += 0.45f)
            {
                Instantiate(objects[1], new Vector3(x, y), Quaternion.identity);
                currObjects++;
            }
        
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
        ball.gameObject.SetActive(true);
        music.Play();
        yield return new WaitForSeconds(0);
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

    public void NextLevel()
    {
        SceneManager.LoadScene(currScene);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(nextScene);
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

        if(gType == 0)
        {
            btnLeft.SetActive(true);
            btnRight.SetActive(true);
        }

        btnBtnStart.SetActive(false);
        btnTouchStart.SetActive(false);
        btnAccStart.SetActive(false);

        StartCoroutine(DelayedStart());
    }
    #endregion    
}

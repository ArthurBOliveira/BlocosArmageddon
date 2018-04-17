using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject ballObject;
    public GameObject playerObject;

    public GameObject imgDegrade;
    public GameObject btnRestart;
    public GameObject btnContinue;
    public GameObject btnMenuBack;

    public GameObject btnLeft;
    public GameObject btnRight;
    public GameObject btnNewBall;
    public GameObject btnEquipment;

    public GameObject GameplaysOptions;
    public GameObject EquipmentsOptions;

    public Text txtTime;
    public Text txtTimeChange;
    public Text txtCountDown;
    public Text txtScore;
    public Text txtScoreTime;

    public string currScene;
    public string nextScene;
    public string achievCode;
    public string leaderboardCode;
    public string levelPickerScene;

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
        EquipmentsOptions.SetActive(true);
        GameplaysOptions.SetActive(false);

        imgDegrade.SetActive(false);
        btnEquipment.SetActive(false);
        btnNewBall.SetActive(false);
        btnContinue.SetActive(false);
        btnRestart.SetActive(false);
        btnMenuBack.SetActive(false);
        time = initTime;
        isCountingTime = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnToLevelPicker();

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
        btnMenuBack.SetActive(true);
        imgDegrade.SetActive(true);
    }

    private void CompleteAchievement()
    {
        if (!Social.localUser.authenticated) return;

        Social.ReportProgress(achievCode, 100, (bool sucess) => { });
    }

    private void SaveScore(int score)
    {
        if (!Social.localUser.authenticated) return;

        Social.ReportScore(score, leaderboardCode, (bool sucess) => { });
    }

    private IEnumerator Win()
    {
        ball.gameObject.SetActive(false);
        isCountingTime = false;
        txtCountDown.text = "You win!";
        txtScore.text = "Score: " + score;
        yield return new WaitForSeconds(0.75f);
        txtScoreTime.text = "x" + time.ToString("000");

        yield return new WaitForSeconds(0.75f);
        txtScoreTime.text = "";
        score += (int)(time * 2);
        txtScore.text = "Score: " + (score).ToString("0000");

        CompleteAchievement();
        SaveScore(score);

        btnRestart.SetActive(true);
        btnContinue.SetActive(true);
        btnMenuBack.SetActive(true);
        imgDegrade.SetActive(true);

        yield return new WaitForSeconds(0);
    }

    private IEnumerator DelayedStart()
    {
        Time.timeScale = 1;
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
        btnEquipment.SetActive(true);
        btnNewBall.SetActive(true);

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
        AddTime(-5);

        ball.InitialKick();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
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
        btnRestart.SetActive(Time.timeScale == 0);
        btnMenuBack.SetActive(Time.timeScale == 0);
        imgDegrade.SetActive(Time.timeScale == 0);
    }

    public void PickGameType(int gType)
    {
        player.gType = (GameType)gType;

        if (gType == 0)
        {
            btnLeft.SetActive(true);
            btnRight.SetActive(true);
        }

        GameplaysOptions.SetActive(false);

        StartCoroutine(DelayedStart());
    }

    public void PickEquipment(int eType)
    {
        Equipments type = (Equipments)eType;

        switch (type)
        {
            case Equipments.Missiles:
                btnEquipment.GetComponent<MissileEquipment>().enabled = true;
                Destroy(btnEquipment.GetComponent<StrongBallEquipment>());
                break;

            case Equipments.Strength:
                btnEquipment.GetComponent<StrongBallEquipment>().enabled = true;
                Destroy(btnEquipment.GetComponent<MissileEquipment>());
                break;
        }

        EquipmentsOptions.SetActive(false);
        GameplaysOptions.SetActive(true);
    }

    public void AddTime(float addTime)
    {
        time += addTime;
        StartCoroutine(TimeChangeAnimation(addTime));
    }

    public void ReturnToLevelPicker()
    {
        SceneManager.LoadScene(levelPickerScene);
    }
    #endregion
}

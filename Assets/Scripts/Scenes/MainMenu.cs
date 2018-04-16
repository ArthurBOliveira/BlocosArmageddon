using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject btnAchievements;
    public GameObject btnLeaderboards;

    private Text txtUser;

    private void Awake()
    {
        txtUser = GameObject.Find("txtUser").GetComponent<Text>();
    }

    private void Start()
    {
        btnAchievements.SetActive(false);
        btnLeaderboards.SetActive(false);

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        GoogleLogin();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("ScenePicker");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void Infinity()
    {
        SceneManager.LoadScene("Infinity");
    }

    public void Site()
    {
        Application.OpenURL("https://nivelhard.herokuapp.com/");
    }

    public void GoogleLogin()
    {
        Social.localUser.Authenticate((bool sucess) =>
        {
            if (!sucess) return;
            txtUser.text = ((PlayGamesLocalUser)Social.localUser).userName;

            btnAchievements.SetActive(true);
            btnLeaderboards.SetActive(true);
        });        
    }

    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }

    public void ShowLeaderboardUI()
    {
        Social.ShowLeaderboardUI();
    }
}

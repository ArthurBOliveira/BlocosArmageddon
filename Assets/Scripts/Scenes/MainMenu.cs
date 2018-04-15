using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Text txtUser;
    private Text txtLog;

    private GooglePlayHelper gpHelper;

    private void Start()
    {
        gpHelper = new GooglePlayHelper();

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
        // requests the email address of the player be available.
        // Will bring up a prompt for consent.
        .RequestEmail()
        // requests a server auth code be generated so it can be passed to an
        //  associated back end server application and exchanged for an OAuth token.
        .RequestServerAuthCode(false)
        // requests an ID token be generated.  This OAuth toeesken can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        txtUser = GameObject.Find("txtUser").GetComponent<Text>();
        txtLog = GameObject.Find("txtLog").GetComponent<Text>();
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
            txtLog.text += "SignIn: " + sucess + "; ";
            txtUser.text = ((PlayGamesLocalUser)Social.localUser).userName;
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

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class GooglePlayHelper
{
    /// <summary>
    /// Initialize PlayGamesPlatform
    /// </summary>
    public void Initialize()
    {
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
    }

    /// <summary>
    /// Sign in the player to Google Play
    /// </summary>
    /// <returns>Status of Sucess</returns>
    public bool SignIn()
    {
        bool result = false;

        Social.localUser.Authenticate((bool sucess) => { result = sucess; });

        return result;
    }

    /// <summary>
    /// Unlock a specific Achievement for the Logged Player
    /// </summary>
    /// <param name="achievCode">Code of the Achievement</param>
    /// <returns>Status of Sucess</returns>
    public bool UnlockAchievement(string achievCode)
    {
        bool result = false;

        Social.ReportProgress(achievCode, 50f, (bool sucess) => { result = sucess; });

        return result;
    }

    /// <summary>
    /// Report the Player Score for a Leaderboard
    /// </summary>
    /// <param name="score">Player Score</param>
    /// <param name="leaderboadCode">Code of the Leaderboard</param>
    /// <returns>Status of Sucess</returns>
    public bool ReportScore(int score, string leaderboadCode)
    {
        bool result = false;

        Social.ReportScore(score, leaderboadCode, (bool sucess) => { result = sucess; });

        return result;
    }

    public string ReturnLoggedUserName()
    {
        return ((PlayGamesLocalUser)Social.localUser).userName;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}

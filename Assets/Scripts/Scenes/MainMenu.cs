using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Loading");
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
}

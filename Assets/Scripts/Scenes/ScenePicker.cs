using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenePicker : MonoBehaviour
{
    public GameObject buttonsPanel;
    public GameObject loadingPanel;
    public GameObject warningPanel;
    public Button btnNext;
    public Text txtLoading;

    private bool isLoading;
    private AsyncOperation ao;

    private void Start()
    {
        isLoading = false;       
        loadingPanel.SetActive(false);

        if (Social.localUser.authenticated)
        {
            warningPanel.SetActive(false);
            buttonsPanel.SetActive(true);
        }
        else
        {
            warningPanel.SetActive(true);
            buttonsPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) BackToMenu();

        if (isLoading && ao.progress >= 0.9f)
        {
            btnNext.gameObject.SetActive(true);
            txtLoading.gameObject.SetActive(false);
        }
    }

    public void ShowLevels()
    {
        warningPanel.SetActive(false);
        buttonsPanel.SetActive(true);
    }

    public void PickLevel(string level)
    {
        isLoading = true;
        buttonsPanel.SetActive(false);
        loadingPanel.SetActive(true);

        ao = SceneManager.LoadSceneAsync(level);
        ao.allowSceneActivation = false;
    }

    public void StartLevel()
    {
        ao.allowSceneActivation = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

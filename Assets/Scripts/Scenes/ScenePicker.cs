using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenePicker : MonoBehaviour
{
    public GameObject buttonsPanel;
    public GameObject loadingPanel;
    public Button btnNext;
    public Text txtLoading;

    private bool isLoading;
    private AsyncOperation ao;

    private void Start()
    {
        isLoading = false;
        buttonsPanel.SetActive(true);
        loadingPanel.SetActive(false);
    }

    public void PickLevel(string level)
    {
        isLoading = true;
        buttonsPanel.SetActive(false);
        loadingPanel.SetActive(true);

        ao = SceneManager.LoadSceneAsync(level);
        ao.allowSceneActivation = false;
    }

    private void Update()
    {
        if (isLoading && ao.progress >= 0.9f)
        {
            btnNext.gameObject.SetActive(true);
            txtLoading.gameObject.SetActive(false);
        }
    }

    public void StartLevel()
    {
        ao.allowSceneActivation = true;
    }
}

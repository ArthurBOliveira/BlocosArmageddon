using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Button btnNext;
    public Text txtLoading;

    private AsyncOperation ao;

    private void Start()
    {
        btnNext.gameObject.SetActive(false);
        ao = SceneManager.LoadSceneAsync("Level 1");
        ao.allowSceneActivation = false;
    }    

    private void Update()
    {
        if(ao.progress >= 0.9f )
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

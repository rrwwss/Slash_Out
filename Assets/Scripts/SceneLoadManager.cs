using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance { get; private set; }
    public int MainInt { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        AudioManager.Instance.Slider = null;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
        AudioManager.Instance.Slider = null;
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(2);
        AudioManager.Instance.Slider = null;
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(3);
        AudioManager.Instance.Slider = null;
    }

    public void SetMainInt(int value)
    {
        MainInt = value;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}

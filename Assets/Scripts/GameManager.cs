using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton to acces the variable globally
    public static GameManager Instance;

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

    // To change the scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // To reload the scene
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }

    public void LoadOutdoors()
    {
        SceneManager.LoadScene("02_Outdoors");
    }

    public void LoadIndoors()
    {
        SceneManager.LoadScene("03_Indoors");
    }

    public void LoadVictory()
    {
        SceneManager.LoadScene("04_Victory");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("05_GameOver");
    }

}

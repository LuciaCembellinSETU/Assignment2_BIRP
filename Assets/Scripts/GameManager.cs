using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton to access the variable globally
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

    // Loads a scene and updates cursor behavior before transition
    public void LoadScene(string sceneName)
    {
        if (sceneName == "01_MainMenu" || sceneName == "04_Victory" || sceneName == "05_GameOver")
            UnlockCursor(); // Unlock cursor for menu scenes
        else
            LockCursor(); // Lock cursor for gameplay scenes

        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        LockCursor(); // Gameplay scenes usually have locked cursors
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        UnlockCursor();
        SceneManager.LoadScene("01_MainMenu");
    }

    public void LoadOutdoors()
    {
        LockCursor();
        SceneManager.LoadScene("02_Outdoors");
    }

    public void LoadIndoors()
    {
        LockCursor();
        SceneManager.LoadScene("03_Indoors");
    }

    public void LoadVictory()
    {
        UnlockCursor();
        SceneManager.LoadScene("04_Victory");
    }

    public void LoadGameOver()
    {
        UnlockCursor();
        SceneManager.LoadScene("05_GameOver");
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

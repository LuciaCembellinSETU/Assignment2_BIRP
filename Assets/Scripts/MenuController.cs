using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayButton()
    {
        GameManager.Instance.LoadOutdoors(); 
    }

    public void VictoryButton()
    {
        GameManager.Instance.LoadMainMenu();
    }

    public void GameOverRespawnButton()
    {
        Debug.Log("Cargando Indoors...");
        GameManager.Instance.LoadIndoors();
    }

    public void GameOverPlayAgainButton()
    {
        Debug.Log("Cargando MainMenu...");
        GameManager.Instance.LoadMainMenu();
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}

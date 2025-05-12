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

    public void GameOverRestartLevelButton()
    {
        GameManager.Instance.LoadIndoors();
    }

    public void GameOverRestartButton()
    {
        GameManager.Instance.LoadMainMenu();
    }
}

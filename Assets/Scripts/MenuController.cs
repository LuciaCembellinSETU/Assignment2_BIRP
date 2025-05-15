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

    public void GameOverPlayAgainButton()
    {
        GameManager.Instance.LoadMainMenu();
    }
}

using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameScenes gameScene;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player contact the box collider
        if (other.CompareTag("Player"))
        {
            if(gameScene == GameScenes.MainMenu)
                GameManager.Instance.LoadMainMenu();
            else if(gameScene == GameScenes.Outdoors)
                GameManager.Instance.LoadOutdoors();
            else if (gameScene == GameScenes.Indoors)
                GameManager.Instance.LoadIndoors();
            else if (gameScene == GameScenes.Victory)
                GameManager.Instance.LoadVictory();
            else if (gameScene == GameScenes.GameOver)
                GameManager.Instance.LoadGameOver();
        }
    }
}

using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameScenes gameScene; // Scene to load
    public float delay = 0f; // Delay before loading the scene (default: 0 seconds)

    private bool isTriggered = false; // Tracks if player has triggered the event
    private float timer = 0f; // Timer for counting the delay

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            TriggerSceneChange(delay); // Call the new scene change method
        }
    }

    public void TriggerSceneChange(float delay)
    {
        if (isTriggered) return; // Prevent multiple triggers
        this.delay = delay;
        isTriggered = true;
        timer = 0f;
    }

    private void Update()
    {
        if (isTriggered)
        {
            timer += Time.deltaTime; // Increment the timer

            if (timer >= delay) // If delay has passed, load the scene
            {
                LoadScene();
                isTriggered = false; // Reset trigger to prevent multiple executions
            }
        }
    }

    private void LoadScene()
    {
        if (gameScene == GameScenes.MainMenu)
            GameManager.Instance.LoadMainMenu();
        else if (gameScene == GameScenes.Outdoors)
            GameManager.Instance.LoadOutdoors();
        else if (gameScene == GameScenes.Indoors)
            GameManager.Instance.LoadIndoors();
        else if (gameScene == GameScenes.Victory)
            GameManager.Instance.LoadVictory();
        else if (gameScene == GameScenes.GameOver)
            GameManager.Instance.LoadGameOver();
    }
}

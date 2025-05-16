using UnityEngine;

public class Victory : MonoBehaviour
{
    private PlayerVictory playerVictory;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerVictory = player.GetComponent<PlayerVictory>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerVictory != null)
        {
            Invoke(nameof(DelayedWinTrigger), 1f);
        }
    }

    private void DelayedWinTrigger()
    {
        playerVictory.ActivateWinTrigger();
    }
}

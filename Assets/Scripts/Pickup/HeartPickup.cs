using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount = 10; // Amount of health to restore

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null) // Ensure the player exists
            {
                playerHealth.Heal(healAmount); // Restore health
                Destroy(gameObject); // Remove the heart object
            }
        }
    }
}

using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public GameObject finalDoor; // Reference to the door
    public GameObject treasure; // Reference to the treasure

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Detect if the Player enters the trigger
        {
            finalDoor.GetComponent<Animator>().SetTrigger("OpenDoor"); // Play door animation
        }
    }
}

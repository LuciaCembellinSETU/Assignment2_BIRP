using UnityEngine;

public class PlayerVictory : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivateWinTrigger()
    {
        animator.SetTrigger("win");
    }
}

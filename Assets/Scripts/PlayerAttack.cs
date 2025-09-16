using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public bool hasWeapon = false;
    private ScaredNPC currentNPC = null;

    void Update()
    {
        if (hasWeapon && currentNPC != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            animator.SetBool("isAttacking", true);
            currentNPC.Die(); // Llama al método para que muera el NPC
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNPC = other.GetComponent<ScaredNPC>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            if (currentNPC != null && other.gameObject == currentNPC.gameObject)
            {
                currentNPC = null;
            }
        }
    }
}

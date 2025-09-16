using UnityEngine;
using System.Collections;
using TMPro;

public class ScaredNPC : MonoBehaviour
{
    private Animator animator;
    bool isDead = false;
    GameController gameController;

    [Header("Referencias de UI")]
    public GameObject weaponMessageUI;     // Mensaje cuando el jugador TIENE arma
    [Header("Llave y victoria")]
    public GameObject keyPrefab;            // Prefab de la llave
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        // Asegúrate de ocultar los mensajes al inicio
        if (weaponMessageUI != null) weaponMessageUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameController.userHasAllPicture())
        {
            PlayerAttack player = other.GetComponent<PlayerAttack>();
            if (player != null && player.hasWeapon)
            {
                animator.SetBool("IsScared", true);
                if (weaponMessageUI != null)
                {
                    weaponMessageUI.SetActive(true);
                    StartCoroutine(HideWeaponMessageAfterSeconds(3f)); // ⬅️ Oculta el mensaje tras 3 seg
                }
            }
            else
            {
                gameController.showNoPictureMessage();
            }
        }
        else
        {
            gameController.showNoPictureMessage();
        }
    }

    IEnumerator HideWeaponMessageAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (weaponMessageUI != null)
        {
            weaponMessageUI.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsScared", false);
            //  Ocultar mensaje cuando el jugador sale
            if (weaponMessageUI != null) weaponMessageUI.SetActive(false);
        }
    }
    public void Die()
    {
        if (isDead) return;
        isDead = true;

        animator.SetTrigger("Die");
        // Reproducir sonido de muerte
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Desactiva el collider si ya no quieres que interactúe
        GetComponent<Collider2D>().enabled = false;
        // Instanciar la llave en el punto indicado
        if (keyPrefab != null)
        {
            keyPrefab.SetActive(true);
        }
    }
}
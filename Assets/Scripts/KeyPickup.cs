using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject victoryPanel;
    public AudioSource victoryAudioSource;   // Reproductor de audio
    public AudioClip victoryClip;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (victoryPanel != null)
            {
                Debug.Log("Activando VictoryPanel...");
                victoryPanel.SetActive(true);
                Debug.Log("VictoryPanel activo: " + victoryPanel.activeInHierarchy);
                // Reproducir sonido de victoria
                if (victoryAudioSource != null && victoryClip != null)
                {
                    victoryAudioSource.PlayOneShot(victoryClip);
                }
            }
            GameController gc = FindAnyObjectByType<GameController>();
            if (gc != null)
            {
                gc.isGameActive = false;
            }

            Time.timeScale = 0f; // Pausar el juego

            Destroy(gameObject); // Eliminar la llave
        }
    }
}
using UnityEngine;
using System.Collections;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float timeLeft; //tiempo de inicio 
    //verifica si tiene el puzzle
    private bool hasLeftSidePicture;
    private bool hasRightSidePicture;
    //verifica si el juego esta activo
    public bool isGameActive;
    public GameObject hiloSangre;
    public GameObject faltaCompletarFoto;
    public GameObject seAcercaSinFoto;
    public GameObject fotoCompleta;
    public GameObject seAcercaSinArma;
    public GameObject GameOverPanel;
    public GameObject BoxTime;
    public AudioSource gameOverAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasLeftSidePicture = false;
        hasRightSidePicture = false;
        timeLeft = 120;
        isGameActive = true;
        if (hiloSangre != null)
        {
            hiloSangre.SetActive(true);
            StartCoroutine(HideGameObjectAfterDelay(hiloSangre, 3f));
        }
        StartCoroutine(TimerCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0f)
            return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 && GameOverPanel != null && isGameActive)
        {
            isGameActive = false;
            GameOverPanel.SetActive(true);
            Debug.Log("Game Over");
            BoxTime.SetActive(false);

            Time.timeScale = 0f;

            // Desactivar el movimiento del jugador
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                MonoBehaviour movementScript = player.GetComponent<MonoBehaviour>(); // Reemplaza con tu script real, como PlayerMovement
                if (movementScript != null)
                {
                    movementScript.enabled = false;
                }

            }
            // Reproducir el clip de audio
            if (gameOverAudio != null)
            {
                gameOverAudio.Play();
            }
        }

    }

    public bool userHasLeftSidePicture()
    {
        return hasLeftSidePicture;
    }

    public void setLeftSidePictureTaken()
    {
        hasLeftSidePicture = true;
        if (faltaCompletarFoto != null)
        {
            faltaCompletarFoto.SetActive(true);
            StartCoroutine(HideGameObjectAfterDelay(faltaCompletarFoto, 3f));
        }
        StartCoroutine(TimerCountDown());
    }

    public bool userHasAllPicture()
    {
        return hasRightSidePicture;
    }

    public void setAllPictureTaken()
    {
        hasRightSidePicture = true;
        if (fotoCompleta != null)
        {
            fotoCompleta.SetActive(true);
            StartCoroutine(HideGameObjectAfterDelay(fotoCompleta, 3f));
        }
        StartCoroutine(TimerCountDown());
    }

    public void showNoLeftSideMessage()
    {
        if (seAcercaSinFoto != null)
        {
            seAcercaSinFoto.SetActive(true);
            StartCoroutine(HideGameObjectAfterDelay(seAcercaSinFoto, 3f));
        }
        StartCoroutine(TimerCountDown());
    }

    public void showNoPictureMessage()
    {
        PlayerAttack player = GameObject.FindWithTag("Player")?.GetComponent<PlayerAttack>();

        if (player != null && player.hasWeapon)
        {
            // No mostrar mensaje si ya tiene el arma
            return;
        }

        if (seAcercaSinArma != null)
        {
            seAcercaSinArma.SetActive(true);
            StartCoroutine(HideGameObjectAfterDelay(seAcercaSinArma, 3f));
        }
    }

    IEnumerator TimerCountDown()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(0.2f);
            timeText.text = "" + Mathf.Round(timeLeft);
        }

    }
    private static IEnumerator HideGameObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}


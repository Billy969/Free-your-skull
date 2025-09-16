using TMPro;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private static void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.CompareTag("Position"))
        {
            Debug.Log("Esta en la zona");
        }
    }
}

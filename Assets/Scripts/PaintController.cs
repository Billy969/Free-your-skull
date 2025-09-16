using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PaintController : MonoBehaviour
{
    public GameObject picture2;
    public GameObject pictureTot;
    public GameObject pictureTotWall;
    public GameObject weapon;
    public GameObject leftWallPicture;
    GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainPlayer")
        {
            Debug.Log("El jugador me choco");
            if (gameController.userHasLeftSidePicture())
            {
                if (leftWallPicture != null){
                    leftWallPicture.SetActive(true);
                    gameController.setAllPictureTaken();
                }
                if (weapon != null){
                    weapon.SetActive(true);
                }
            } else {
                gameController.showNoLeftSideMessage();
            }

            
        }
       
    }
}
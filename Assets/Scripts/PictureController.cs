using UnityEngine;

public class PictureController : MonoBehaviour
{
    GameController gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision with photo");
        if (collision.gameObject.name == "MainPlayer"){
            gameController.setLeftSidePictureTaken();
            this.gameObject.SetActive(false);
            //   objectText.text = "haz obtenido un trozo de retrato: ";
            Debug.Log("has obtenido un pedazo de una foto. " + gameController.userHasLeftSidePicture());
        }
    }
}

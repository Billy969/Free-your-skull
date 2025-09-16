using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene() 
    {
        SceneManager.LoadScene(sceneName);
    }
}

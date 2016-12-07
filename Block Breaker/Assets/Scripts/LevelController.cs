using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public void loadLevel(string name)
    {
        Debug.Log("Level Load requested for: " + name);
        SceneManager.LoadScene(name);
        Brick.brickCount = 0;
    }

    public void quitRequest()
    {
        Debug.Log("Quit Request called");
        Application.Quit();
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

    private int loadedScene;
	// Use this for initialization
	public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
	
	// Update is called once per frame
	public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}

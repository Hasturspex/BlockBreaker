using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public void LoadLevel(string name)
    {
        Debug.Log("Level Load requested for: " + name);
        Application.LoadLevel(name);
    }
    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit(); 
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void BrickDestroyed()
    {
        if(Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}

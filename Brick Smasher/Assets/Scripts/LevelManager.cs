using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadLevel(string levelName)
    {
        Application.LoadLevel(levelName);
    }
	
	// Update is called once per frame
	public void Quit()
    {
        Application.Quit();
    }
}

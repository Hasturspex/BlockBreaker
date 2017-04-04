using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;
	public Text texts;
	private string lives = "3";

	void Update() {
		texts.text = lives;
        if (lives == "0")
        {
            levelManager.LoadLevel("Lose");
        }
    }

	void OnTriggerEnter2D(Collider2D trigger)
	{
		  if (lives == "3") {
			lives = "2";
		} else if (lives == "2") {
			lives = "1";
		} else if (lives == "1") {
			lives = "0";
		}

	}
}

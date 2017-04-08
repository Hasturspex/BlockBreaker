using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	public Text texts;
	public Text life;
	private string lives = "3";

	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

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
			life.text = "Life";
		} else if (lives == "1") {
			lives = "0";
			life.text = "Lives";
		}

	}
}

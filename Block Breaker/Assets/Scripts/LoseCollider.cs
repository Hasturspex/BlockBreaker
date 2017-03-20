using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {


    private LevelManager levelManager;
    public Paddle paddle;
    
    
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        paddle = FindObjectOfType<Paddle>();
    }

	void OnTriggerEnter2D (Collider2D collision)
    {
        print("Trigger");

            levelManager.LoadLevel("Lose Screen");
            Brick.breakableCount = 0;
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        print("Collision");
        levelManager.LoadLevel("Lose Screen");

    }   

   
}

using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int maxHits;
    private bool isBreakable;
    private LevelManager levelManager;

    public static int breakableCount = 0;
    public int timesHit;
    public Sprite[] hitSprites;

	void Start () {
        isBreakable = (this.tag == "Breakable");
        timesHit = 0;
        maxHits = hitSprites.Length + 1;

        if(isBreakable)
        {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        if (isBreakable)
        {
            HandleHits();
        }
 
	}


    void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)    
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        } else
        {
            LoadSprite();
        }
    }

    void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}

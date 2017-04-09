using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int maxHits;
    private bool isBreakable;
    private LevelManager levelManager;

    public static int breakableCount = 0;
    public int timesHit;
    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smokePuff;

    void Start () {
        isBreakable = (this.tag == "Breakable");
        timesHit = 0;
        maxHits = hitSprites.Length + 1;

        if(isBreakable)
        {
            breakableCount++;
            print(breakableCount);
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
            AudioSource.PlayClipAtPoint(crack, transform.position);
            breakableCount--;
            levelManager.BrickDestroyed();
            SmokePuffing();
            Destroy(gameObject);
        } else
        {
            LoadSprite();
        }
    }

    void SmokePuffing()
    {
        GameObject puff = Instantiate(smokePuff, transform.position, Quaternion.identity) as GameObject;
        puff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}

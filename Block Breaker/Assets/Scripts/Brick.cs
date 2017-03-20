using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    private int maxHits;
    private int timesHit;
    private LevelManager level;
    private bool IsBreakable;

    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip audioClip;
    public GameObject smoke;


    // Use this for initialization
    void Start () {
        IsBreakable = (this.tag == "Breakable");
        if(IsBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        level = GameObject.FindObjectOfType<LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        if (IsBreakable)
            HandleHits();
    }

    void HandleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            breakableCount--;
            level.BrickDestroyed();
            print(breakableCount + " bricks left!");
            PuffSmoke();
            Destroy(gameObject);
        }
        else
            LoadSprites();
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Sprite missing!");
    }

    void SimulateWin()
    {
        level.LoadNextLevel();
    }
}

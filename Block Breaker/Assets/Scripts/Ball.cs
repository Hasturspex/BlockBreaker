using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    public Rigidbody2D rigid;
    private AudioSource audioSource;
    public static bool hasStarted = false;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();


    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {
            //Lock The ball on the paddle
            transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Left Mouse Button Clicked!");

                rigid.velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        rigid.velocity += tweak;
        if(hasStarted)
        audioSource.Play();
    }

}

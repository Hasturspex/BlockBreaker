using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    private Ball ball;

    public bool autoPlay = false;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

	// Update is called once per frame
	void Update () {
			if(autoPlay)
        {
            AutoPlay();
        } else
        {
            MoveByMouse();
        }
	}

    void AutoPlay()
    {
        float ballPos = Mathf.Clamp(ball.transform.position.x, -7.5f, 7.5f);
        Vector3 paddle = new Vector3(ballPos, this.transform.position.y, this.transform.position.z);
        this.transform.position = paddle;
    }

    void MoveByMouse()
    {
        float mousePos = Mathf.Clamp((Input.mousePosition.x / Screen.width * 16) - 8, -7.5f, 7.5f);
        Vector3 paddle = new Vector3(mousePos, this.transform.position.y, this.transform.position.z);
        this.transform.position = paddle;
    }
}

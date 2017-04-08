using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Ball : MonoBehaviour {

	private Paddle paddle;
    public Text txt;
    private Vector3 paddleToBall;
    private bool start = false;
    private bool change1 = false;
    private bool change2 = false;
	// Use this for initialization
	void Start () {
        
		paddle = GameObject.FindObjectOfType<Paddle> ();
        paddleToBall = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(txt.text == "2" && !change1)
        {
            start = false;
            change1 = true;
        }   else if(txt.text == "1" && !change2)
        {
            start = false;
            change2 = true;
        }
            if(!start)
            {
                this.transform.position = paddle.transform.position + paddleToBall;

                if (Input.GetMouseButtonDown(0))
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 15f);
                    start = true;
                }
            }
            
          

	}


}

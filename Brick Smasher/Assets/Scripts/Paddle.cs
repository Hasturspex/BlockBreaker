using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mousePos = Mathf.Clamp((Input.mousePosition.x / Screen.width * 16)-8, -7.5f , 7.5f);
		Vector3 paddle = new Vector3 (mousePos, this.transform.position.y, this.transform.position.z);

		this.transform.position = paddle;	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    Vector3 paddlePos;

    private Ball ball;

	// Use this for initialization
	void Start () {
		paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            paddlePos.x = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 1.0f, 15.0f);
            this.transform.position = paddlePos;
        } else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        paddlePos.x = Mathf.Clamp(ball.transform.position.x, 1.0f, 15.0f);
        this.transform.position = paddlePos;
    }
}

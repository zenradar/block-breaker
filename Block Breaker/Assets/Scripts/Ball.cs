using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool launched;
    private AudioSource source;

    // Use this for initialization
    void Start () {
        launched = false;
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;

        source = GetComponent<AudioSource>();
        source.enabled = false;
        source.volume = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!launched) {
            // Lock the ball to the paddle  
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for the left mouse key to be released to launch the ball
            if (Input.GetMouseButtonUp(0))
            {
                launched = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 15f);
                source.enabled = true;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        GetComponent<Rigidbody2D>().AddForce(tweak);
        if (source.enabled) source.Play();
    }


}

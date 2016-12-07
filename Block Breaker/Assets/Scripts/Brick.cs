using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int brickCount = 0;
    public AudioClip destroyed;
    public GameObject smoke;

    private int maxHits;
    private int timesHit;
    private bool breakable;
    private AudioSource sourceHit;
    private ParticleSystem system;

    // Use this for initialization
    void Start () {
        timesHit = 0;
        maxHits = hitSprites.Length + 1;
        breakable = (tag == "Breakable");
        if (breakable)
        {
            brickCount++;
        }
        sourceHit = GetComponent<AudioSource>();
        sourceHit.enabled = false;
        sourceHit.volume = 0.5f;


    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (breakable)
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
                system = smokePuff.GetComponent<ParticleSystem>();
                var mainModule = system.main;
                mainModule.startColor = gameObject.GetComponent<SpriteRenderer>().color;

                AudioSource.PlayClipAtPoint(destroyed, transform.position);
                Destroy(gameObject);
                brickCount--;
                if (brickCount == 0)
                {
                    levelCleared();
                }
            }
            else
            {
                sourceHit.enabled = true;
                sourceHit.Play();               
                LoadSprite();

            }

        }
    }

    private void LoadSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit-1];
    }

    //TODO Level is cleared when all bricks have been destroyed
    private void levelCleared() {
        int lastLevel = SceneManager.sceneCountInBuildSettings;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < lastLevel) {
            SceneManager.LoadScene(nextScene);
        } else {
            SceneManager.LoadScene("Win");
        }
        
    }
}

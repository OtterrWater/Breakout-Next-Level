using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay, isCreated;
    public Transform paddle, powerup;
    public float speed;
    public GameManager gm;
    public AudioSource ballImplact1, ballImplact2, brickbreakSound;
    //public Vector2 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        } 
        else if (gm.win)
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            return;
        }
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        //jump maps to spacebar(trigger)
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    //dead collider(triggers game lose)
    void OnTriggerEnter2D(Collider2D other)
        //needs colliders, @least 1 w. rigid body
    {
        if (other.CompareTag("Bottom"))
        {
            Debug.Log("ball hit bottom of screen");
            rb.velocity = Vector2.zero;
            inPlay = false;

            gm.UpdateLives(-1);
        }
    }

    //kills bricks
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            brickScript bs = other.gameObject.GetComponent<brickScript>();
            if(bs.hitsToBreak > 1)
            {
                bs.BrickBroke();
                brickbreakSound.Play();
            }
            else
            {
                int chance = Random.Range(1, 101);
                if (chance > 70 && !isCreated && gm.lives < 3)
                {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                    isCreated = true;
                }

                ballImplact1.Play();
                ballImplact2.Play();
                Destroy(other.gameObject);

                gm.UpdateScore(+1);
                gm.UpdateBrickCount();
            }
        }
    }
}

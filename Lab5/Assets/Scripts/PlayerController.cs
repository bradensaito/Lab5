using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public bool rightFace = true;
    public int speed = 10;
    public int jump = 10;

    public Transform firePoint;
    public GameObject bullet;
    [SerializeField]
    private bool isVulnerable = true;
    private int count = 0;

    public GameObject life1, life2, life3;

    [SerializeField]
    private int health;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        health = MainMenu.lives;
	}

    void Update()
    {
        health = MainMenu.lives;
        life1.gameObject.SetActive(false);
        life2.gameObject.SetActive(false);
        life3.gameObject.SetActive(false);

        if (health >= 1)
        {
            life1.gameObject.SetActive(true);
        }
        if(health >= 2)
        {
            life2.gameObject.SetActive(true);
        }
        if(health >= 3)
        {
            life3.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        if(rb2d.velocity.y > -0.1 && rb2d.velocity.y < 0.1)
        {
            if (Input.GetKey("up") || Input.GetKey("space"))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                FindObjectOfType<AudioManager>().Play("Jump");
            }
        }

        if(moveHorizontal < 0 && rightFace)
        {
            flip();
        }
        else if(moveHorizontal > 0 && !rightFace)
        {
            flip();
        }


        if(Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift"))
        {
            FindObjectOfType<AudioManager>().Play("Shot1");
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }

        if(!isVulnerable)
        {
            count++;
            if(count >=100)
            {
                isVulnerable = true;
                count = 0;
            }
        }

	}

    void flip()
    {
        rightFace = !rightFace;
        Vector3 flipScale = transform.localScale;
        flipScale.x = flipScale.x * -1;
        transform.localScale = flipScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" || collision.tag == "Shield") && isVulnerable)
        {
            //take damage;
            FindObjectOfType<AudioManager>().Play("Ouch");
            MainMenu.lives -= 1;
            isVulnerable = false;
            if(life3.gameObject.activeInHierarchy)
            {
                //break 3
                MainMenu.score -= 200;
            }
            else if(life2.gameObject.activeInHierarchy)
            {
                //break 2
                MainMenu.score -= 200;
            }
            else if (life1.gameObject.activeInHierarchy)
            {
                //break 1 game over
                MainMenu.score -= 200;
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}

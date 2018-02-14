using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool rightFace = true;
    public int speed = 10;
    public int jump = 10;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        if(rb2d.velocity.y > -0.1 && rb2d.velocity.y < 0.1)
        {
            if(Input.GetKeyDown("space"))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
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
	}

    void flip()
    {
        rightFace = !rightFace;
        Vector3 flipScale = transform.localScale;
        flipScale.x = flipScale.x * -1;
        transform.localScale = flipScale;
    }
}

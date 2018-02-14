using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Patrol : MonoBehaviour {

    public int speed;
    private Rigidbody2D rb2d;
    public bool rightFace = true;
    private int direction = 1;

    [SerializeField]
    private float prevX;
    [SerializeField]
    private float curX;

    [SerializeField]
    private int count;

    // Use this for initialization
    void Start () {

        count = 0;

        rb2d = GetComponent<Rigidbody2D>();

        prevX = 0;
        curX = 100;

        if (!rightFace)
        {
            flip();
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        curX = rb2d.position.x;


        rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);
        
        if(curX == prevX)
        {
            count++;
        }
        else
        {
            count = 0;
        }

        if(count >= 2)
        {
            rightFace = !rightFace;
            flip();
            count = 0;
        }

        prevX = rb2d.position.x;

	}

    void flip()
    {
        rightFace = !rightFace;
        Vector3 flipScale = transform.localScale;
        flipScale.x = flipScale.x * -1;
        transform.localScale = flipScale;
        direction = -direction;
    }

}

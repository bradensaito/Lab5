using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

    public int damage;

    private bool isTargetable = true;

    public PlayerController player;

    private int count;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<PlayerController>();
        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        count++;

        if(count > 200)
        {
            Destroy(gameObject);
        }
        if(!isTargetable)
        {
            isTargetable = true;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && isTargetable)
        {
            isTargetable = false;
            Enemy1Controller hurtEnemy = collision.gameObject.GetComponent<Enemy1Controller>();
            hurtEnemy.takeDamage(damage);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}

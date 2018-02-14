using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletControl : MonoBehaviour {

    public float speed = 5;
    private Rigidbody2D rb2d;

    private bool isTargetable = true;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}

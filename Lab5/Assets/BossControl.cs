using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    [System.Serializable]
    public class Enemy1Stats
    {
        public int maxHealth;
        private int curHealth;
        public int currentHealth
        {
            get { return curHealth; }
            set { curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }




    public Enemy1Stats stats = new Enemy1Stats();

    private int count = 0;

    public GameObject bullet;
   // public GameObject bigBullet;
    public Transform highShot;
    public Transform lowShot;

    private Transform nextShot;

    void Start()
    {
        stats.Init();
        count = 0;
    }


    private void FixedUpdate()
    {
        count++;
        if(count >= 75)
        {
            if((int)Time.time % 2 == 1)
            {
                nextShot = highShot;
            }
            else
            {
                nextShot = lowShot;
            }
            shoot();
            count = 0;
        }
    }

    public void takeDamage(int damage)
    {
        stats.currentHealth -= damage;

        //Debug.LogError("took damage");
        if (stats.currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
        MainMenu.score += 1000;
    }

    void shoot()
    {
        Instantiate(bullet, nextShot.position, nextShot.rotation);
    }
}

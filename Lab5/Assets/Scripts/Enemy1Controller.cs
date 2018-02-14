using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour {


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

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        stats.Init();

        statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth);

    }


    public void takeDamage(int damage)
    {
        stats.currentHealth -= damage;
        statusIndicator.SetHealth(stats.currentHealth, stats.maxHealth);
        //Debug.LogError("took damage");
        if(stats.currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
        MainMenu.score += 100;

        Debug.LogWarning("should play ouch");
        FindObjectOfType<AudioManager>().PlaySound("Ouch");

    }
}

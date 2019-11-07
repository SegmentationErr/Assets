using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2D;
    private Transform target;
    int speed = 3;
    public float maxHealth = 100;
    private float health;
    private Transform healthBar;
    public List<GameObject> potions;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
        healthBar = gameObject.transform.Find("HealthBar").transform.Find("Bar");
        potions = new List<GameObject>();
        potions.Add(GameObject.Find("potion_blue_small"));
        potions.Add(GameObject.Find("potion_red_small"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) > 1.3)
            xDir = target.position.x > transform.position.x ? 1 : -1;

        if (Mathf.Abs(target.position.y - transform.position.y) > 1.3)
            yDir = target.position.y > transform.position.y ? 1 : -1;
            
        Vector2 movement = new Vector2(xDir, yDir);
        rb2D.MovePosition(rb2D.position + movement  *speed * Time.fixedDeltaTime);

        healthBar.localScale = new Vector3(health/maxHealth, 1f, 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
        // health -= BulletEffect.damage;
        float damage = collision.gameObject.GetComponent<BulletEffect>().getDamage();
        health = health > damage ? health-damage : 0;
        }   
        
        if (health == 0) {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            rb2D.bodyType = RigidbodyType2D.Static;
            
            animator.SetBool("enemyDead", true);
            Destroy(gameObject, 1f);
            
            Instantiate(potions[(int)Random.Range(0, 2)], transform.position, Quaternion.identity).GetComponent<PickupTrigger>().enabled=true;

            health = -0.001f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("持续碰撞");
        //animator.SetTrigger("playerDead");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("离开碰撞");
    }
}

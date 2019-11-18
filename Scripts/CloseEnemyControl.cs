using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyControl : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2D;
    private Transform target;
    [SerializeField]
    private float speed;
    public float maxHealth = 100;
    private float health;
    private Transform healthBar;
    private List<GameObject> potions;
    private GameObject coin;
    private bool faceright; 
    private bool jumping = false;
    private bool isdead = false;
    private bool attack = false;
    private GameObject player;
    private PlayerControl pc;
    [SerializeField]
    private float damage = 1;
    float interval = 1.1f;
    float nextTime = 1;
    public GameObject attackEffect;
    public AudioSource attackSound;
    void Start()
    {
        //speed = 2f;
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerControl>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
        healthBar = gameObject.transform.Find("HealthBar").transform.Find("Bar");
        potions = new List<GameObject>();
        potions.Add(GameObject.Find("potion_blue_small"));
        potions.Add(GameObject.Find("potion_red_small"));
        coin = GameObject.Find("coin");

        faceright = true;
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("walk", false);
        animator.SetBool("attack", false);
        animator.SetBool("dead", false);
        animator.SetBool("jump", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isdead == false)
        {
            //if (this.transform.GetChild(2).gameObject.tag != "EnemyArrow")
            //{
            //print("move");
            //animator.SetBool("walk", true);
            moveTowards();
            //moveRandom();
            //}




            if (Vector2.Distance(this.transform.position, player.transform.position) < 1.5f)
            {
                //print(Vector2.Distance(this.transform.position, player.transform.position));
                animator.SetBool("attack", true);

                //animator.Play("attacking", -1, 0f);
                print(Time.time);
                //print(nextTime);
                if (Time.time >= nextTime)
                {
                    

                    pc.health.CurrentVal -= damage;

                    if(Time.time-nextTime > 1)
                    {
                        nextTime = Time.time - 1;
                    }
                 
                     nextTime += interval;
                    
                    
                    CollisionEffect();
                    attackSound.Play();
                }
                

            }
            else animator.SetBool("attack", false);
        }
        healthBar.localScale = new Vector3(health / maxHealth, 1f, 1f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // health -= BulletEffect.damage;
            float damage = collision.gameObject.GetComponent<BulletEffect>().getDamage();
            Damaged(damage);
        }
        
        /*else if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("attack", true);
            animator.Play("attacking", -1, 0f);
        }*/
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Debug.Log("持续碰撞");
        //animator.SetTrigger("playerDead");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        //animator.SetBool("attack", false);
        //Debug.Log("离开碰撞");
    }
    public void Damaged(float damage)
    {
        if (health == -0.001f) return;
        health = health > damage ? health - damage : 0;
        if (health == 0)
        {
            isdead = true;
            //animator.SetBool("dead", true);
            //animator.SetBool("enemyDead", true);
            animator.SetTrigger("enemyDead");

            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            rb2D.bodyType = RigidbodyType2D.Static;

            Destroy(gameObject, 1.2f);

            Instantiate(potions[(int)Random.Range(0, 2)], transform.position, Quaternion.identity).GetComponent<PickupTrigger>().enabled = true;

            for (int i = 0; i < (int)Random.Range(0, 5); i++)
            {
                Instantiate(coin, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
            }
            health = -0.001f;
            
        }
    }

    private void moveTowards()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) > 1)
            xDir = target.position.x > transform.position.x ? 1 : -1;

        if (Mathf.Abs(target.position.y - transform.position.y) > 1)
            yDir = target.position.y > transform.position.y ? 1 : -1;
        
        Vector2 movement = new Vector2(xDir, yDir);
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);

        float xDiff = target.position.x - transform.position.x;
        float yDiff = target.position.y - transform.position.y;
        if (xDiff > 0 && yDiff > 0)
        {
            animator.SetBool("walk", true);
            if (faceright == false)
            {
                Flip();
            }
        }
        else if(xDiff > 0 && yDiff < 0)
        {
            animator.SetBool("walk", true);
            if (faceright == false)
            {
                Flip();
            }
        }
        else if(xDiff < 0 && yDiff < 0)
        {
            animator.SetBool("walk", true);
            if (faceright == true)
            {
                Flip();
            }
        }
        else if(xDiff < 0 && yDiff > 0)
        {
            animator.SetBool("walk", true);
            if (faceright == true)
            {
                Flip();
            }
        }
        else if(xDiff == 0 && yDiff == 0)
        {
            animator.SetBool("walk", false);
        }

    }

    private void moveRandom()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) < 10)
            xDir = (int)Random.Range(-5f, 5f);


        if (Mathf.Abs(target.position.y - transform.position.y) < 10)
            yDir = (int)Random.Range(-5f, 5f);

        Vector2 movement = new Vector2(xDir, yDir);
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        faceright = !faceright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void CollisionEffect()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        GameObject effect = Instantiate(attackEffect, player.transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);

    }
}

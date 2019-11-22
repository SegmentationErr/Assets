using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2D;
    private Transform target;
    int speed = 3;
    public float maxHealth = 100;
    private float health;
    private Transform healthBar;
    private List<GameObject> potions;
    private GameObject coin;
    private bool faceright;

    public bool state1;
    private bool state2;
    private bool moveRight;
    private bool changing;

    void Start()
    {
        faceright = true;
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

        animator.SetBool("state2", false);
        animator.SetBool("changed", false);

        state1 = true;
        state2 = false;
        moveRight = true;
        changing = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.health <= maxHealth*0.7)
        {
            StartCoroutine(Example());
            

        }
        if (!changing)
        {
            if (state1)
            {
                moveHoriz();

            }

        }



        healthBar.localScale = new Vector3(health / maxHealth, 1f, 1f);
    }

    IEnumerator Example()
    {
        animator.SetBool("changed", true);
        changing = true;
        transform.GetChild(transform.childCount - 2).gameObject.SetActive(false);
        transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        animator.SetBool("state2", true);
        state1 = false;
        state2 = true;
        changing = false;
        if (!changing)
        {
            moveTowards();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // health -= BulletEffect.damage;
            float damage = collision.gameObject.GetComponent<BulletEffect>().getDamage();
            print(changing);
            /*if (!changing)
            {*/
                Damaged(damage);
            /*}*/
            
        }
        if(collision.gameObject.tag == "Wall")
        {
            Flip();
            moveRight = !moveRight;
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
    public void Damaged(float damage)
    {
        if (health == -0.001f) return;
        health = health > damage ? health - damage : 0;
        if (health == 0)
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            rb2D.bodyType = RigidbodyType2D.Static;

            animator.SetBool("enemyDead", true);
            Destroy(gameObject, 1f);

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
        if (Mathf.Abs(target.position.x - transform.position.x) > 3)
            xDir = target.position.x > transform.position.x ? 1 : -1;

        if (Mathf.Abs(target.position.y - transform.position.y) > 3)
            yDir = target.position.y > transform.position.y ? 1 : -1;

        Vector2 movement = new Vector2(xDir, yDir);
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);

        float xDiff = target.position.x - transform.position.x;
        float yDiff = target.position.y - transform.position.y;
        if (xDiff > 0 && yDiff > 0)
        {
            if (faceright == false)
            {
                Flip();
            }
        }
        else if (xDiff > 0 && yDiff < 0)
        {
            if (faceright == false)
            {
                Flip();
            }
        }
        else if (xDiff < 0 && yDiff < 0)
        {
            if (faceright == true)
            {
                Flip();
            }
        }
        else if (xDiff < 0 && yDiff > 0)
        {
            if (faceright == true)
            {
                Flip();
            }
        }
        else if (xDiff == 0 && yDiff == 0)
        {

        }
    }

    private void moveHoriz()
    {
        int xDir;
        int yDir = 0;
        if (moveRight)
        {
            xDir = 1;
        }
        else
        {
            xDir = -1;
        }

        Vector2 movement = new Vector2(xDir, yDir);
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);

       /* if (xDir > 0)
        {
            if (faceright == false)
            {
                Flip();
            }
        }
        else if (xDir < 0)
        {
            if (faceright == true)
            {
                Flip();
            }
        }*/
    }



    void Flip()
    {
        faceright = !faceright;
        //Vector3 theScale = transform.localScale;
        //Vector3 theRota = transform.localRotation;
        //theScale.x *= -1;
        //transform.localScale = theScale;
        transform.Rotate(0, -180f, 0);
    }
}

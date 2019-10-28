using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2D;
    private Transform target;
    int speed = 3;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) > 1)
            xDir = target.position.x > transform.position.x ? 1 : -1;

        if (Mathf.Abs(target.position.y - transform.position.y) > 1)
            yDir = target.position.y > transform.position.y ? 1 : -1;
            
        Vector2 movement = new Vector2(xDir, yDir);
        rb2D.MovePosition(rb2D.position + movement  *speed * Time.fixedDeltaTime);
        //transform.Translate(movement * 3* Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("enemyDead");
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
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
        //Debug.Log("离开碰撞");
    }
}

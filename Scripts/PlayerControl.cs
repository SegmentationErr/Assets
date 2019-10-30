using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 7f;
    public Animator animator;
    private Rigidbody2D player;

    [SerializeField]
    public BarState health;

    //[SerializeField]
    //public BarState energy;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
        animator.SetFloat("Face", 1);
    }

    private void Awake()
    {
        health.Initialize();
        //energy.Initialize();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float mHorzontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(mHorzontal, mVertical);

        animator.SetFloat("Horizontal", mHorzontal);
        animator.SetFloat("Vertical", mVertical);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x > 0.1) {
            animator.SetFloat("Face", movement.x);
        } else if (movement.x < -0.1) {
            animator.SetFloat("Face", movement.x);
        }

        player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal += 10;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        //player.constraints = RigidbodyConstraints2D.FreezeAll;\
        if (collision.gameObject.tag == "Enemy") 
        {
            health.CurrentVal -= 10;
            //energy.CurrentVal -= 10;
        }
        
            //animator.SetTrigger("playerDead");
        //Debug.Log("开始碰撞");


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Debug.Log("持续碰撞");
        //animator.SetTrigger("playerDead");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Debug.Log("离开碰撞");
    }

 /*   public Vector2 playerPosition()
    {
        Vector2 position = transform.position;
        return position;
    }*/


}

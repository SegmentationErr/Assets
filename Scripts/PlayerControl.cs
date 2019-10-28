using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public Animator animator;
    private Rigidbody2D player;

    void Start()
    {
        
        //player.constraints = RigidbodyConstraints2D.FreezeAll;
        player = GetComponent<Rigidbody2D>();
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mHorzontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(mHorzontal, mVertical);

        player.MovePosition(player.position + movement * 7 * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //player.constraints = RigidbodyConstraints2D;
        //player.constraints = RigidbodyConstraints2D.FreezeAll;\
        if (collision.gameObject.tag == "Enemy") { }
            //animator.SetTrigger("playerDead");
        //Debug.Log("开始碰撞");
    }


}

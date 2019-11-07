using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log("wall持续碰撞");
        //animator.SetTrigger("playerDead");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log("离开碰撞");
    }
}

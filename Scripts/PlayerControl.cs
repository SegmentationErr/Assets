using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public Animator animator;
    private Rigidbody2D player;

    [SerializeField]
    public BarState health;

    [SerializeField]
    public GameObject gameOver;

    //[SerializeField]
    //public BarState energy;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
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

        if(health.CurrentVal == 0)
        {
            EndGame();
        }
        player.MovePosition(player.position + movement * 7 * Time.fixedDeltaTime);
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
            if (health.CurrentVal > 0)
            {
                health.CurrentVal -= 50;
            }

            
            
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

    public void EndGame()
    {
        gameOver.SetActive(true);
    }


}

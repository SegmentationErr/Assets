using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody2D rb2D;
    public GameObject destroyEffect;
    public float damage = 10;
    private GameObject player;
    private PlayerControl pc;
    float m_distanceTraveled;
    [SerializeField]
    private float distance = 6f;
    // Start is called before the first frame update
    void Start()
    {
        //distance = 3f;
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        pc = player.GetComponent<PlayerControl>();
        m_distanceTraveled = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_distanceTraveled < distance)
        {
            //print(m_distanceTraveled);
            Vector3 oldPosition = transform.position;

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            m_distanceTraveled += Vector3.Distance(oldPosition, transform.position);
        }
        else this.gameObject.SetActive(false);
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }

    void DestroyBullet()
    {
        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        //Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        //print(this.transform.);
        if (this.gameObject.tag == "EnemyBullet")
        {
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Door")
            {
                if (collision.gameObject.tag == "Player") pc.health.CurrentVal -= damage;
                CollisionEffect();
            }
            if (collision.gameObject.tag == "Enemy")
            {
                //print("enemy collision");
                this.gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Door")
        {
            //if (collision.gameObject.tag == "Wall") print("wall");
            //if (collision.gameObject.tag == "Enemy") print("Enemy");
            //if (collision.gameObject.tag == "Player") pc.health.CurrentVal -= 5;

            CollisionEffect();
        }
    }

    private void CollisionEffect()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Destroy(gameObject);
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

    public float getDamage()
    {
        return damage;
    }
}

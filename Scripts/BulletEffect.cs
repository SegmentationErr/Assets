using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    private float speed = 20;
    public float lifeTime = 0.3f;
    private Rigidbody2D rb2D;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyBullet() {
        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        //Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        if (collision.gameObject.tag == "Enemy"  || collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.tag == "Wall") print("wall");
            if (collision.gameObject.tag == "Enemy") print("Enemy");
            //Invoke("DestroyBullet", lifeTime);
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(this.gameObject);
        }
            

        //rb2D.gameObject.SetActive(false);
        //Debug.Log("开始碰撞");
        //animator.SetTrigger("playerDead");
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

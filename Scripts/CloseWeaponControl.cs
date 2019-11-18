using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeaponControl : MonoBehaviour
{
    private GameObject enemyAtackable=null;
    public GameObject effect;
    private enemyControl eC;
    private CloseEnemyControl cec;
    public AudioSource attackSound;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0.03399992f, -0.068f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        if (((rotz < -90f || rotz > 90f) && transform.localScale.y > 0) ||
                (rotz >= -90f && rotz <= 90f && transform.localScale.y < 0))
        {
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
        if (enemyAtackable != null && Mathf.Abs(enemyAtackable.transform.position.x - transform.position.x) > 1.3)
        {
            //print("out of range");
            enemyAtackable = null;
        }
        if (Input.GetMouseButton(0))
        {

            transform.Rotate(0,0,-80f);

            if (enemyAtackable != null)
            {
                eC = enemyAtackable.GetComponent<enemyControl>();
                cec = enemyAtackable.GetComponent<CloseEnemyControl>();
                //print("attackable");
                if (eC != null)
                {
                    GameObject effect2 = Instantiate(effect, enemyAtackable.transform.position, Quaternion.identity);
                    attackSound.Play();
                    eC.Damaged(5);
                    Destroy(effect2, 0.4f);
                }
                if (cec != null)
                {
                    GameObject effect3 = Instantiate(effect, enemyAtackable.transform.position, Quaternion.identity);
                    attackSound.Play();
                    cec.Damaged(5);
                    Destroy(effect3, 0.4f);
                }


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            //print("fish trigger");
            enemyAtackable = collision.gameObject;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //print("fish trigger stay");
            enemyAtackable = collision.gameObject;
        }
    }

    /*void OrbitAround()
    {
        transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
    }*/
   /* IEnumerator Attack()
    {

    }*/


}

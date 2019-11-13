using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeaponControl : MonoBehaviour
{
    private Animator ani;
    private GameObject enemyAtackable=null;
    public GameObject effect;
    private enemyControl eC;

    public GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        transform.localPosition = new Vector3(0.1f, -0.068f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);

        if (enemyAtackable != null && Mathf.Abs(enemyAtackable.transform.position.x - transform.position.x) > 1.3)
        {
            //print("out of range");
            enemyAtackable = null;
        }
        if (Input.GetMouseButton(0))
        {
            OrbitAround();
            //Vector3 point = transform.localRotation;
            //Vector3 axis = Vector3.forward;
            //this.transform.RotateAround(point, axis, Time.deltaTime * 10);

            transform.Rotate(0,0,-60f);

            /*float tiltAroundZ = Input.GetAxis("Horizontal") * 60f;
            float tiltAroundX = Input.GetAxis("Vertical") * 60f;

            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);*/

            // transform.rotation = Quaternion.Euler(Vector3.forward * 60f);
            //print("rotation");
            if (enemyAtackable != null)
            {
                eC = enemyAtackable.GetComponent<enemyControl>();
                //print("attackable");
                GameObject effect2 = Instantiate(effect, enemyAtackable.transform.position, Quaternion.identity);
                eC.Damaged(5);
                Destroy(effect2, 0.4f);

            }
            //ani.SetTrigger("attack");
            //ani.SetTrigger("new");
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

    void OrbitAround()
    {
        transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
   /* IEnumerator Attack()
    {

    }*/


}

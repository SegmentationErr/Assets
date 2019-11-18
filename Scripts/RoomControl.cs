using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    private EdgeCollider2D edge;
    private GameObject closedDoor;
    private GameObject openedDoor;
    private Sprite closedSprite;
    private Sprite openedSprite;
    // Start is called before the first frame update
    void Start()
    {
        closedDoor = GameObject.Find("environment/door01");
        openedDoor = GameObject.Find("environment/door02");
        closedSprite = closedDoor.GetComponent<SpriteRenderer>().sprite;
        openedSprite = openedDoor.GetComponent<SpriteRenderer>().sprite;

        foreach (MonoBehaviour c in transform.GetComponentsInChildren<WeaponControl>())
        {
            c.enabled = false;
        }
        foreach (MonoBehaviour c in transform.GetComponentsInChildren<enemyControl>())
        {
            c.enabled = false;
        }
        foreach (MonoBehaviour c in transform.GetComponentsInChildren<CloseEnemyControl>())
        {
            c.enabled = false;
        }
        edge = gameObject.GetComponent<EdgeCollider2D>();
        //print(transform.GetChild(2));
    }

    // Update is called once per frame
    void Update()
    {
        bool enemyLeft = false;
        foreach (Transform child in transform)
        {
            if (child.tag == "Enemy")
            {
                enemyLeft = true;
            }
        }
        if (!enemyLeft)
        {
            edge.isTrigger = true;
            closedToOpenedDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //print(other.tag);
        if (other.tag == "Bullet")
        {
            other.GetComponent<BulletEffect>().Invoke("CollisionEffect", 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            edge.isTrigger = false;
            openToClosedDoor();
            foreach (MonoBehaviour c in transform.GetComponentsInChildren<WeaponControl>())
            {
                c.enabled = true;
            }
            foreach (MonoBehaviour c in transform.GetComponentsInChildren<enemyControl>())
            {
                c.enabled = true;
            }
            foreach (MonoBehaviour c in transform.GetComponentsInChildren<CloseEnemyControl>())
            {
                c.enabled = true;
            }
        }
    }

    private void openToClosedDoor()
    {
        //print(transform.GetChild(0));
        if (transform.GetChild(0) != null)
        {
            foreach (Transform child in transform.GetChild(0).transform)
            {
                child.GetComponent<SpriteRenderer>().sprite = closedSprite;
            }
        }
    }
    private void closedToOpenedDoor()
    {
        //print(transform.GetChild(0));
        if (transform.GetChild(0) != null)
        {
            foreach (Transform child in transform.GetChild(0).transform)
            {
                child.GetComponent<SpriteRenderer>().sprite = openedSprite;
            }
        }
    }


}

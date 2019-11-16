using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    private EdgeCollider2D edge;
    // Start is called before the first frame update
    void Start()
    {
        foreach (MonoBehaviour c in transform.GetComponentsInChildren<WeaponControl>()) {
            c.enabled = false;
        }
        foreach (MonoBehaviour c in transform.GetComponentsInChildren<enemyControl>()) {
            c.enabled = false;
        }
        edge = gameObject.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool enemyLeft = false;
        foreach (Transform child in transform) {
            if (child.tag == "Enemy") {
                enemyLeft = true;
            }
        }
        if (! enemyLeft) {
            edge.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print(other.tag);
        if (other.tag == "Bullet")
        {
            edge.isTrigger = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            edge.isTrigger = false;
            foreach (MonoBehaviour c in transform.GetComponentsInChildren<WeaponControl>()) {
                c.enabled = true;
            }
            foreach (MonoBehaviour c in transform.GetComponentsInChildren<enemyControl>()) {
                c.enabled = true;
            }
        }
    }
}

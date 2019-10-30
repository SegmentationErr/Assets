using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    private GameObject hand;
    void Start()
    {
        hand = GameObject.Find("character2/WeaponHolder");
        if (this.transform.parent != hand.transform)
        {
            gameObject.GetComponent<WeaponControl>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.transform.SetParent(hand.transform);
            this.gameObject.SetActive(false);
            transform.localPosition = new Vector3(0.03399992f, -0.068f,0);
            gameObject.GetComponent<WeaponControl>().enabled = true;
        }
        
        
    }
}

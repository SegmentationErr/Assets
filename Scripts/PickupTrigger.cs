using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    private GameObject hand;
    //private WeaponSwitching ws;
    //private GameObject player;
    void Start()
    {
        hand = GameObject.Find("character2/WeaponHolder");
        //ws = GetComponent<WeaponSwitching>();
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
            //transform.position = other.transform.position;


            transform.localPosition = new Vector3(0.03399992f, -0.068f, 0);
            gameObject.GetComponent<WeaponControl>().enabled = true;
            //ws.SelectedWeapon();
            //ws.Invoke("SelectedWeapon", 0f);
            //gameObject.SetActive(false);
            
        }
        
        
    }
}

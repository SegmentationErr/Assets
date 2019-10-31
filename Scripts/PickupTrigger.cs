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
        // gameObject.tag = "Enemy";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        // Debug.Log("1"+gameObject.tag);
        // Debug.Log("2"+gameObject.tag == "Potion");
        // Debug.Log("3"+gameObject.CompareTag("Potion"));
        if (gameObject.CompareTag("Potion")) {
            Debug.Log("oooooo");
        } 

        if (other.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.tag);

            if (gameObject.tag == "Potion") {
                Debug.Log("oooooo");
            }
            else {
                this.transform.SetParent(hand.transform);
                this.gameObject.SetActive(false);
                transform.localPosition = new Vector3(0.03399992f, -0.068f,0);
                gameObject.GetComponent<WeaponControl>().enabled = true;
            }
        }
    }
}

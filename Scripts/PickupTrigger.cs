using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    private GameObject hand;
    private GameObject messageBoard;
    private GameObject inventory;
    private GameObject items = null;
    void Start()
    {
        messageBoard = GameObject.Find("HUD/MessageBoard");
        inventory = GameObject.Find("HUD/Inventory");
        if(messageBoard!=null) messageBoard.SetActive(false);

        hand = GameObject.Find("character2/WeaponHolder");
        if (this.transform.parent != hand.transform)
        {
            if(gameObject.GetComponent<WeaponControl>()!=null) gameObject.GetComponent<WeaponControl>().enabled = false;
        }
        // gameObject.tag = "Enemy";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && items != null)
        {
            this.transform.SetParent(hand.transform);
            transform.localPosition = new Vector3(0.03399992f, -0.068f, 0);
            gameObject.GetComponent<WeaponControl>().enabled = true;
            this.gameObject.SetActive(false);

            inventory.GetComponent<Inventory>().Invoke("updateSlot", 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Potion") {
                Debug.Log("oooooo");
            }
            else if(this.gameObject.tag=="Weapon"){
                items = other.gameObject;
                messageBoard.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Potion")
            {
                Debug.Log("oooooo");
            }
            else if (this.gameObject.tag == "Weapon")
            {
                messageBoard.SetActive(false);
                items = null;
            }
        }
    }
}

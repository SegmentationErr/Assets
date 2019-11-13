using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    private GameObject hand;
    private GameObject messageBoard;
    private GameObject inventory;
    private GameObject player;
    private GameObject items = null;
    private PlayerControl pc;
    private WeaponSwitching ws;
    private static bool initializeMessage = true;
    void Start()
    {
        messageBoard = GameObject.Find("HUD/MessageBoard");
        if (this.gameObject.tag == "Weapon" && initializeMessage)
        {
            messageBoard.gameObject.SetActive(false);
            initializeMessage = false;
        }

        inventory = GameObject.Find("HUD/Inventory");
        player = GameObject.Find("character2");
        pc = player.GetComponent<PlayerControl>();

        //if (messageBoard != null)
        //{
        //messageBoard.gameObject.SetActive(false); 
        // print("check message board  " + (messageBoard == null));
        //}

        hand = GameObject.Find("character2/WeaponHolder");
        ws = hand.GetComponent<WeaponSwitching>();
        if (this.transform.parent != hand.transform)
        {
            if (gameObject.GetComponent<WeaponControl>() != null) gameObject.GetComponent<WeaponControl>().enabled = false;
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
            if (this.gameObject.tag == "Potion")
            {
                pc.health.CurrentVal += 20;
                this.gameObject.SetActive(false);
            }
            else if (this.gameObject.tag == "PotionE")
            {
                ws.energy.CurrentVal += 20;
                this.gameObject.SetActive(false);
            }
            else if (this.gameObject.tag == "Weapon")
            {
                items = other.gameObject;
                print("on trigger enter check message board  " + (messageBoard == null));
                messageBoard.SetActive(true);
            } else if (this.gameObject.tag == "Coin") {
                other.GetComponent<PlayerControl>().addCoin();
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag!= "Potion" & this.gameObject.tag != "PotionE")
        {
            //   else if (this.gameObject.tag == "Weapon")
            //  {
            print("on trigger exit check message board  " + (messageBoard == null));
            messageBoard.SetActive(false);
            items = null;
            //}
        }
    }
}

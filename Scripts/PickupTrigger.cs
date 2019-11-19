using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupTrigger : MonoBehaviour
{
    private GameObject hand;
    private GameObject messageBoard;
    private GameObject inventory;
    private GameObject player;
    private GameObject items = null;
    private PlayerControl pc;
    private WeaponSwitching ws;

    private void Awake()
    {
        messageBoard = GameObject.Find("HUD/MessageBoard");
    }

    void Start()
    {
        if (this.gameObject.tag == "Weapon" && messageBoard.activeSelf)
        {
             messageBoard.gameObject.SetActive(false);
        }

        inventory = GameObject.Find("HUD/Inventory");
        //player = GameObject.Find("character2");
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerControl>();

        //hand = GameObject.Find("character2/WeaponHolder");
        hand = player.transform.GetChild(0).gameObject;
        ws = hand.GetComponent<WeaponSwitching>();
        if (this.transform.parent != hand.transform)
        {
            if (gameObject.GetComponent<CloseWeaponControl>() != null) gameObject.GetComponent<CloseWeaponControl>().enabled = false;
            if (gameObject.GetComponent<WeaponControl>() != null) gameObject.GetComponent<WeaponControl>().enabled = false;
            
        }
        foreach (Transform weapon in hand.transform)
        {
            weapon.gameObject.GetComponent<PickupTrigger>().enabled = false;
        }
        {

        }
        // gameObject.tag = "Enemy";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && items != null)
        {
            this.transform.SetParent(hand.transform);
            transform.localPosition = new Vector3(0.03399992f, -0.068f, 0);
            //gameObject.GetComponent<WeaponControl>().enabled = true;
            if (gameObject.GetComponent<WeaponControl>() != null) gameObject.GetComponent<WeaponControl>().enabled = true;
            if (gameObject.GetComponent<CloseWeaponControl>() != null) gameObject.GetComponent<CloseWeaponControl>().enabled = true;
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
            else if (this.gameObject.tag == "Weapon" || this.gameObject.tag == "Weapon_moon")
            {
                items = other.gameObject;
                messageBoard.SetActive(true);
            }
            else if (this.gameObject.tag == "Coin")
            {
                other.GetComponent<PlayerControl>().addCoin();
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Weapon")
        {
            messageBoard.SetActive(false);
            items = null;
        }
    }
}


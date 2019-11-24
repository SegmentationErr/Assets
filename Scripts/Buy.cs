using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    private GameObject buttonSelf;
    public GameObject weaponPre;
    private GameObject checkUI;
    private GameObject buyBtn;
    private GameObject cancelBtn;
    public PlayerControl player;
    private int price;
    public string character;

    // Start is called before the first frame update
    void Start()
    {
        checkUI = GameObject.Find("Canvas/Shop/check");
        cancelBtn = checkUI.transform.GetChild(1).gameObject;
        cancelBtn.GetComponent<Button>().onClick.AddListener(ClickCancel);
        this.GetComponent<Button>().onClick.AddListener(BuyStuff);
    }

    // Update is called once per frame
    void Update()
    {
        //print(weaponPre);
    }

    public void BuyStuff()
    {
        // get price
        price = int.Parse(this.GetComponentInChildren<Text>().text);
        // get this stuff
        buttonSelf = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        checkUI.GetComponentInChildren<Text>().text = price.ToString();
        checkUI.SetActive(true);
        buyBtn = checkUI.transform.GetChild(1).gameObject;
        buyBtn.GetComponent<Button>().onClick.AddListener(ClickBuy);
    }

    private void ClickBuy()
    {
        GameObject weaponHolder = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;

        if (weaponHolder.transform.childCount < 4 && this.tag == "shopWeapon")
        {
            // get player coins
            player = GameObject.Find("character 1").GetComponent<PlayerControl>();
            int coins = player.getCoin();
            //print(coins);
            if (coins >= price)
            {
                player.deleteCoin(price);
                GameObject weapon = Instantiate(weaponPre, weaponHolder.transform);
                Destroy(buttonSelf);
            }
            else
            {
                GameObject noMoney = GameObject.Find("Canvas/Shop/noMoney");
                noMoney.SetActive(true);
            }
        }
        else if (this.tag == "shopPotion")
        {
            print("!!!");
        }
        else if (this.tag == "shopCharacter")
        {
            player = GameObject.Find("character 1").GetComponent<PlayerControl>();
            int coins = player.getCoin();
            //print(coins);
            if (coins >= price)
            {
                player.deleteCoin(price);
                if (character == "c1")
                {
                    player.animator.Play("move 0");
                }
                else if (character == "c2")
                {
                    player.animator.Play("move 1");
                }
                else if (character == "c3")
                {
                    player.animator.Play("move 1 0");
                }
                Destroy(buttonSelf);
            }
            else
            {
                GameObject noMoney = GameObject.Find("Canvas/Shop/noMoney");
                noMoney.SetActive(true);
            }
        }
        else
        {
            GameObject bagFull = GameObject.Find("Canvas/Shop/BagFull");
            bagFull.SetActive(true);
        }

        buyBtn.GetComponent<Button>().onClick.RemoveListener(ClickBuy);
        checkUI.SetActive(false);
    }

    private void ClickCancel()
    {
        if (buyBtn != null)
        {
            buyBtn.GetComponent<Button>().onClick.RemoveListener(ClickBuy);
        }
        checkUI.SetActive(false);
    }
}

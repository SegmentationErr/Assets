using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject shop;
    private GameObject UI;

    private void Awake()
    {
        //UI = GameObject.Find("Canvas");
        //shop = GameObject.Find("Canvas/Shop");

    }
    // Start is called before the first frame update


    void Start()
    {
        //UI = GameObject.Find("Canvas");
        //shop = UI.transform.Find("Shop").gameObject;
        shop.SetActive(false);
    }

    // Update is called once per frame
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //print("player collision");
            shop.SetActive(true);
        }

    }
}

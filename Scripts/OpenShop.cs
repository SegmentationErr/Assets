using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private GameObject shop;
    private GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas");
        shop = UI.transform.Find("Shop").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shop.SetActive(true);
        }

    }
}

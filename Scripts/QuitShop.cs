using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitShop : MonoBehaviour
{
    private GameObject shop;
    private GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
        shop = UI.transform.Find("Shop UI").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shop.SetActive(false);
        }

    }
}

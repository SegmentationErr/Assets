using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private GameObject weaponHolder;
    private PlayerControl pc;
    private Sprite s1;
    private Sprite s2;
    private Sprite s3;
    private Sprite s4;
    private Sprite s5;
    private Sprite s6;
    // Start is called before the first frame update
    void Start()
    {
        //weaponHolder = GameObject.Find("character2/WeaponHolder");
        weaponHolder = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSlot();
    }

    void updateSlot()
    {
        setWeapinHolderSprite();
        int i = 0;
        //transform is weaponholder
        foreach (Transform slot in transform)
        {
            GameObject Item = slot.GetChild(0).GetChild(0).gameObject;
            if (i == 0) Item.GetComponent<Image>().sprite = s1;
            else if (i == 1) Item.GetComponent<Image>().sprite = s2;
            else if (i == 2) Item.GetComponent<Image>().sprite = s3;
            else if (i == 3) Item.GetComponent<Image>().sprite = s4;
            else if (i == 4) slot.GetChild(0).GetChild(1).GetComponent<Text>().text = pc.getHealth().ToString();
            else if (i == 5) slot.GetChild(0).GetChild(1).GetComponent<Text>().text = pc.getEnergy().ToString();
            i++;
        }
    }

    private void setWeapinHolderSprite()
    {
        s1 = s2 = s3 = s4 = s5 = s6 = null;
        if (weaponHolder.transform.childCount > 0)
            s1 = weaponHolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

        if (weaponHolder.transform.childCount > 1)
            s2 = weaponHolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;

        if (weaponHolder.transform.childCount > 2)
            s3 = weaponHolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;

        if (weaponHolder.transform.childCount > 3)
            s4 = weaponHolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;

        /*if (weaponHolder.transform.childCount > 4)
            s4 = weaponHolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite;
        
        if (weaponHolder.transform.childCount > 5)
            s4 = weaponHolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite;*/

    }

    void initializeBorderColor()
    {
        foreach (Transform slot in transform)
        {
            slot.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private GameObject weaponHolder;
    private Sprite s1;
    private Sprite s2;
    private Sprite s3;
    private Sprite s4;
    // Start is called before the first frame update
    void Start()
    {
        weaponHolder = GameObject.Find("character2/WeaponHolder");
        updateSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            i++;
        }
    }

    private void setWeapinHolderSprite()
    {
        s1 = weaponHolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

        if(weaponHolder.transform.childCount>1) 
            s2 = weaponHolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;

        if (weaponHolder.transform.childCount > 2)
            s3 = weaponHolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;

        if (weaponHolder.transform.childCount > 3)
            s4 = weaponHolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;

    }

    void initializeBorderColor()
    {
        foreach (Transform slot in transform)
        {
            slot.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}

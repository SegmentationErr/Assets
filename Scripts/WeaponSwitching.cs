using System;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectedWeapon();
    }

    protected void SelectedWeapon()
    {
        int i = 0;
        //transform is weaponholder
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (transform.hasChanged)
        {
            //print("The transform has changed!");
            SelectedWeapon();
            transform.hasChanged = false;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount>=2)
        {
            selectedWeapon = 1;
        }if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount>=3)
        {
            selectedWeapon = 2;
        }if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount>=4)
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            //print("select weapon!!!!!!!!!!!!!!!!!!!");
            SelectedWeapon();
        }

       /* void onTriggerEnter2D(Collider2D collider)
        {
            print("triggerrrrrrrrrrrrrrrrrrrrrr");
        }*/
        
    }
}

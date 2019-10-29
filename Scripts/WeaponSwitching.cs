using System;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    [SerializeField]
    public BarState energy;
    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectedWeapon();
    }
    private void Awake()
    {
        energy.Initialize();
        //energy.Initialize();
    }


    private void SelectedWeapon()
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

        if (previousSelectedWeapon != selectedWeapon)
        {
            //print("select weapon!!!!!!!!!!!!!!!!!!!");
            SelectedWeapon();
        }
        /*if (IsInvoking("Shoot"))
        {
            print("shootttttttttttttttttttttttttttttttttttttttt");
            energy.CurrentVal -= 10;
        }*/

    }
}

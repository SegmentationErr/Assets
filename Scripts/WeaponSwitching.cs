using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{

    [SerializeField]
    public BarState energy;
    public int selectedWeapon = 0;
    private GameObject Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameObject.Find("HUD/Inventory");
        SelectedWeapon();
        Inventory.transform.GetChild(selectedWeapon).GetChild(0).GetComponent<Image>().color = new Color32(100, 100, 100, 255);
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
            SelectedWeapon();
        }
        InitializeBoardColor();
        Inventory.transform.GetChild(selectedWeapon).GetChild(0).GetComponent<Image>().color = new Color32(100, 100, 100, 255);
    }

    void InitializeBoardColor()
    {
        int i = 0;
        foreach(Transform slots in Inventory.transform)
        {
            if (i != selectedWeapon)
            {
                slots.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            i++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class drop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 InitialPosition;
    GameObject weapon;
    GameObject checkUI;
    GameObject yesBtn;
    GameObject cancelBtn;
    GameObject weaponHolder;
    // Start is called before the first frame update
    void Start()
    {
        checkUI = GameObject.FindGameObjectWithTag("Player").transform.GetChild(7).GetChild(2).gameObject;
        cancelBtn = checkUI.transform.GetChild(2).gameObject;
        cancelBtn.GetComponent<Button>().onClick.AddListener(ClickCancel);
        InitialPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        checkUI.SetActive(true);
        yesBtn = checkUI.transform.GetChild(1).gameObject;
        yesBtn.GetComponent<Button>().onClick.AddListener(ClickYes);
        this.transform.localPosition = InitialPosition;

    }

    public void ClickYes()
    {
        weaponHolder = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        GameObject slot = this.transform.parent.parent.gameObject;
        if( slot.name == "Slot1")
        {
            weapon = weaponHolder.transform.GetChild(0).gameObject;
        }else if(slot.name == "Slot2")
        {
            weapon = weaponHolder.transform.GetChild(1).gameObject;
        }
        else if (slot.name == "Slot3")
        {
            weapon = weaponHolder.transform.GetChild(2).gameObject;
        }
        else if (slot.name == "Slot4")
        {
            weapon = weaponHolder.transform.GetChild(3).gameObject;
        }
        // drop weapon
        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        //weapon.transform.parent = GameObject.Find("Grid").transform;
        weapon.transform.parent = gameObjects[0].transform;
        if (weapon.GetComponent<WeaponControl>() != null) weapon.GetComponent<WeaponControl>().enabled = false;
        if (weapon.name == "fish") weapon.GetComponent<CloseWeaponControl>().enabled = false;
        weapon.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        weapon.SetActive(true);
        yesBtn.GetComponent<Button>().onClick.RemoveListener(ClickYes);
        //weapon.
        checkUI.SetActive(false);
    }

    private void ClickCancel()
    {
        if (yesBtn != null)
        {
            yesBtn.GetComponent<Button>().onClick.RemoveListener(ClickYes);
        }
        //print(""+this + this.transform.localPosition);
        this.transform.localPosition = InitialPosition;
        checkUI.SetActive(false);
    }
}

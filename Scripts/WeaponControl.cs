﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    // public float offset
    //public GameObject player;
    public GameObject bullet;
    public GameObject weaponHolder;
    public Transform shotPoint;
    public WeaponSwitching ws;
    private float deltaTime = 0;
    public float maxDeltaTime = 0.5f;
    public AudioSource shootSound;

    [SerializeField]
    private float energyConsume;
    bool playerAlive;


    public float EnergyConsume
    {
        get
        {
            return energyConsume;
        }
        set
        {
            this.energyConsume = value;
  
        }
    }

    void Start()
    {
        playerAlive = true;
        

        weaponHolder = GameObject.Find("character2/WeaponHolder");
        ws = weaponHolder.GetComponent<WeaponSwitching>();
        this.EnergyConsume = energyConsume;

        if (this.transform.parent.tag == "Enemy")
        {
            StartCoroutine(EnemyAttack());
        }
        //ws = gameObject.AddComponent<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAlive = false;
        }
        Shoot();
    }

    public void Shoot()
    {
        //player
        if (this.transform.parent.tag != "Enemy")
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz);
            if ((ws.energy.CurrentVal - energyConsume) >= 0)
            {
                if (deltaTime >= maxDeltaTime)
                {
                    if (Input.GetMouseButton(0))
                    {
                        Instantiate(bullet, shotPoint.position, transform.rotation);
                        //Instantiate(bullet, shotPoint.position, Quaternion.identity);
                        deltaTime = 0;
                        shootSound.Play();
                        ws.energy.CurrentVal -= energyConsume;
                    }
                }
                else
                {
                    deltaTime += Time.deltaTime;
                }
            }
        }  
    }

    IEnumerator EnemyAttack()
    {
        while (playerAlive)
        {
            
            //print(weaponHolder.transform.parent.position);
            Vector3 difference = weaponHolder.transform.parent.position - transform.position;

            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz);

                if (deltaTime >= maxDeltaTime)
                {

                        Instantiate(bullet, shotPoint.position, transform.rotation);
                        //Instantiate(bullet, shotPoint.position, Quaternion.identity);
                        deltaTime = 0;
                        //shootSound.Play();
                        
                    
                }
                else
                {
                    deltaTime += Time.deltaTime;
                }
            
            yield return new WaitForSeconds(0.1f);
        }
        print("player dead");
    }
}

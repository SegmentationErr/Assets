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
    private float shootFrequence = 0.2f;

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

        transform.localPosition = new Vector3(0.03399992f, -0.068f, 0);
        weaponHolder = GameObject.Find("character2/WeaponHolder");
        ws = weaponHolder.GetComponent<WeaponSwitching>();
        this.EnergyConsume = energyConsume;
        if (transform.parent.gameObject.tag == "Enemy")
        {
            StartCoroutine(EnemyAttack());
        }
        //ws = gameObject.AddComponent<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAlive = false;

        }
        Shoot();
    }

    public void Shoot()
    {
        //player
        if (transform.parent.gameObject.tag != "Enemy")
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz);

            if (((rotz < -90f || rotz > 90f) && transform.localScale.y > 0) ||
                (rotz >= -90f && rotz <= 90f && transform.localScale.y < 0)) {
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            }

            

            if ((ws.energy.CurrentVal - energyConsume) >= 0)
            {
                if (deltaTime >= maxDeltaTime)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if(this.gameObject.tag == "Weapon_moon")
                        {
                            PlayershootMode3();
                        }
                        else Instantiate(bullet, shotPoint.position, transform.rotation);

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

    // private void EnemyAttack()
    IEnumerator EnemyAttack()
    {
        while (playerAlive)
        {
            if (deltaTime >= maxDeltaTime)
            {
                if (this.gameObject.tag == "EnemyArrow")
                {
                    shootTrackMul();
                }else if(this.gameObject.tag == "EnemyTank")
                {
                    shootMode3();
                }
                else shootSurround();
                //Instantiate(bullet, shotPoint.position, Quaternion.identity);
                deltaTime = 0;
                shootSound.Play();
                //shootSound.Play();
            }
            else
            {
                deltaTime += Time.deltaTime;
            }
            yield return new WaitForSeconds(shootFrequence);
        }
        print("player dead");
    }
    private void shootTracking()
    {
        Vector3 difference = weaponHolder.transform.parent.position - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }
    private void shootSurround()
    {
        //shoot right
        Vector3 difference = new Vector3(1, 0, 0);
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        //shoot up
        difference = new Vector3(0, 1, 0);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        //shoot left
        difference = new Vector3(-1, 0, 0);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        //shoot down
        difference = new Vector3(0, -1, 0);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        //shoot top-right
        difference = new Vector3(1, 1, 0);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        //shoot up-left
        difference = new Vector3(-1, 1, 0);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);


        //shoot down-right
        difference = new Vector3(1, -1, 0);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        //shoot down-left
        difference = new Vector3(-1, -1, 0);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }

    private void shootTrackMul()
    {
        Vector3 difference = weaponHolder.transform.parent.position - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = weaponHolder.transform.parent.position - transform.position + new Vector3(0f, 0f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(1f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

/*        difference = weaponHolder.transform.parent.position - transform.position + new Vector3(0f, -2f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);*/
    }

    private void shootMode3()
    {
        Vector3 difference = weaponHolder.transform.parent.position - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = weaponHolder.transform.parent.position - transform.position + new Vector3(0f, 1.4f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = weaponHolder.transform.parent.position - transform.position + new Vector3(0f, -1.4f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = weaponHolder.transform.parent.position - transform.position + new Vector3(0f, 0.7f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = weaponHolder.transform.parent.position - transform.position + new Vector3(0f, -0.7f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }

    private void PlayershootMode3()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position + new Vector3(0f, 1.4f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position + new Vector3(0f, -1.4f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position + new Vector3(0f, 0.7f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);

        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position + new Vector3(0f, -0.7f, 0f);
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MultiWeaponControl : MonoBehaviour
{
    // public float offset
    //public GameObject player;
    public GameObject bullet;
    public GameObject weaponHolder;
    public Transform shotPoint;
    public MultiWeaponSwitching ws;
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
        //weaponHolder = GameObject.Find("character2/WeaponHolder");
        // weaponHolder = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        weaponHolder = transform.parent.gameObject;
        ws = weaponHolder.GetComponent<MultiWeaponSwitching>();
        this.EnergyConsume = energyConsume;
    }

    // Update is called once per frame
    void Update()
    {
        if (! transform.parent.parent.GetComponent<NetworkIdentity>().isLocalPlayer) return;

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
                        
                        if (this.gameObject.tag == "Weapon_moon")
                        {
                            PlayershootMode3();
                        }
                        else {
                            if (transform.parent.parent.GetComponent<NetworkIdentity>().isServer) {
                                GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
                                // NetworkServer.Spawn(b);
                                transform.parent.parent.GetComponent<MultiPlayerControl>().sendToClient(b);
                            } else {
                                // GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
                                transform.parent.parent.GetComponent<MultiPlayerControl>().sendToServer(bullet, shotPoint.position, transform.rotation);
                            }
                            // Instantiate(bullet, shotPoint.position, transform.rotation);
                        }
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

    // [Command]
    // void CmdShootFromClient() {
    //     GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
    //     NetworkServer.SpawnWithClientAuthority(b, connectionToClient);
    //     print(123123);
    // }

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

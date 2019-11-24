using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class MultiPlayerControl : NetworkBehaviour
{
    public float speed = 7f;
    public Animator animator;
    private Rigidbody2D player;

    [SerializeField]
    public BarState health;

    [SerializeField]
    public GameObject gameOver;

    private Rigidbody2D body;
    private int coins;

    //[SerializeField]
    //public BarState energy;
    // public GameObject bullet;

    void Start()
    {
        coins = 0;
        player = GetComponent<Rigidbody2D>();
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
        body = this.GetComponent<Rigidbody2D>();
        animator.SetFloat("Face", 1);
        

        if (! isLocalPlayer) {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        health.Initialize();
        SceneManager.sceneLoaded += OnSceneLoaded;
        //energy.Initialize();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (! isLocalPlayer) return;
        float mHorzontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(mHorzontal, mVertical);

        animator.SetFloat("Horizontal", mHorzontal);
        animator.SetFloat("Vertical", mVertical);
        animator.SetFloat("Speed", movement.sqrMagnitude);



        if (movement.x > 0.1)
        {
            animator.SetFloat("Face", movement.x);
        }
        else if (movement.x < -0.1)
        {
            animator.SetFloat("Face", movement.x);
        }

        player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal += 10;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            health.CurrentVal -= 50;
        }

        if (health.CurrentVal <= 0)
        {
            animator.Play("character2Dead");
            
            EndGame();
            body.Sleep();
            this.transform.GetChild(0).gameObject.SetActive(false);
        }

    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //if(this.gameObject != null)
        //{
        if (scene.buildIndex < 2)
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(6).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(7).gameObject.SetActive(false);
        }
        if (scene.buildIndex == 2)
            {
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(6).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(7).gameObject.SetActive(true);
                 health.CurrentVal += health.MaxVal;
                transform.GetChild(0).GetComponent<WeaponSwitching>().energy.CurrentVal = transform.GetChild(0).GetComponent<WeaponSwitching>().energy.MaxVal;

            }
            else if (scene.buildIndex > 2)
            {
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(6).gameObject.SetActive(true);
            }
        //}
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health.CurrentVal -= 5;            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //player.constraints = RigidbodyConstraints2D.FreezeRotation;
        //player.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log("持续碰撞");
        //animator.SetTrigger("playerDead");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //player.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Debug.Log("离开碰撞");
    }

    /*   public Vector2 playerPosition()
       {
           Vector2 position = transform.position;
           return position;
       }*/

    public void EndGame()
    {
        if (SceneManager.GetActiveScene().name == "Room")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            health.CurrentVal += health.MaxVal;
            transform.GetChild(0).GetComponent<WeaponSwitching>().energy.CurrentVal = transform.GetChild(0).GetComponent<WeaponSwitching>().energy.MaxVal;
            gameOver.SetActive(false);
        }
        else
        {
            gameOver.SetActive(true);
        }
    }

    public int getCoin()
    {
        PlayerPrefs.SetInt("n_coins", coins);
       
        return coins;
    }

    public void addCoin()
    {
        coins++;
    }

    public void setCoin(int coin)
    {
        this.coins = coin;
    }

    public void sendToClient(GameObject g) {
        NetworkServer.Spawn(g);
    }

    public void sendToServer(GameObject g, Vector3 position, Quaternion rotation) {
        CmdShootFromClient(g, position, rotation);
    }

    [Command] 
    void CmdShootFromClient(GameObject g, Vector3 position, Quaternion rotation) {
        // GameObject bullet = GetComponentsInChildren<MultiWeaponControl>()[2].bullet;
        // foreach (Transform child in transform) {
        //     if (child.gameObject.active) {
        //         bullet = child.GetComponent<MultiWeaponControl>().bullet;
        //     }
        // }
        GameObject bullet = GetComponentInChildren<MultiWeaponControl>().bullet;
        GameObject b = Instantiate(bullet, position, rotation);
        NetworkServer.SpawnWithClientAuthority(b, connectionToClient);
    }
}
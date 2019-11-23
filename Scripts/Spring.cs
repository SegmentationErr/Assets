using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private GameObject hand;
    private WeaponSwitching ws;
    private GameObject player;
    private PlayerControl pc;
    bool flag; //restore once

    // Start is called before the first frame update
    void Start()
    {
        //flag = true;
        //hand = GameObject.Find("character2/WeaponHolder");
        hand = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        ws = hand.GetComponent<WeaponSwitching>();
        //player = GameObject.Find("character2");
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerControl>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
      
            ws.energy.CurrentVal = ws.energy.MaxVal;
            pc.health.CurrentVal = pc.health.MaxVal;

        
    }

}

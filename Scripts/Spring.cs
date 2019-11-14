﻿using System.Collections;
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
        flag = true;
        hand = GameObject.Find("character2/WeaponHolder");
        ws = hand.GetComponent<WeaponSwitching>();
        player = GameObject.Find("character2");
        pc = player.GetComponent<PlayerControl>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flag)
        {
            ws.energy.CurrentVal = ws.energy.MaxVal;
            pc.health.CurrentVal = pc.health.MaxVal;
            flag = false;
        }
        else print("have restored once!");
        
    }

}

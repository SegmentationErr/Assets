using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    // Start is called before the first frame update
    public int level;
    public int coin;

    public PlayerData(){
        this.coin = GameObject.FindWithTag("Player").GetComponent<PlayerControl>().getCoin();
        this.level = PlayerPrefs.GetInt("LevelReached");

    }
}

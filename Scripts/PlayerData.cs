using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    // Start is called before the first frame update
    public int level;
    public int coin;

    public PlayerData(PlayerControl  player){
    	coin = player.getCoin();
        level = PlayerPrefs.GetInt("LevelReached");
    	
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    // Start is called before the first frame update
    public int level;
    public int coin;
    // public GameObjectp[] weaponlist;
    public PlayerData(){
        
        GameObject player =GameObject.FindObjectWithTag("Player"); 
        GameObject weponholder = player.transform.getChild(0).gameObject;
        this.coin = GameObject.FindWithTag("Player").GetComponent<PlayerControl>().getCoin();
        this.level = PlayerPrefs.GetInt("LevelReached");
        foreach (transform weapon in weponholder)
        {
           weaponlist.append(weapon.gameObject); 
        }
    }
}

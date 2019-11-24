using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    // Start is called before the first frame update
    public int level;
    public int coin;
    public List<string> weaponlist = new List<string>();
    public PlayerData(){

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject weponholder = player.transform.GetChild(0).gameObject;
        this.coin = GameObject.FindWithTag("Player").GetComponent<PlayerControl>().getCoin();
        this.level = PlayerPrefs.GetInt("LevelReached");
        int num = weponholder.transform.childCount;
        for(int i = 0; i< num; i++)
        {
            Debug.Log(weponholder.transform.GetChild(i));

            weaponlist.Add(weponholder.transform.GetChild(i).name);
        }
        
    }
}

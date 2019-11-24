using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarttoRoom : MonoBehaviour
{
    private GameObject weaponHolder;
    public GameObject[] weaponslist;

    private void Start()
    {
        weaponHolder = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;

    }
    void Update()
    {
        
       

    }

    public void NewGame()
    {
        SceneManager.LoadScene("Room");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelReached",1);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Multi_Room");
    }

    public void LoadGame()
    {
        //Debug.Log("load");
        PlayerData data = SaveSystem.LoadPlayer();
        PlayerPrefs.SetInt("n_coin",data.coin);
        //Debug.Log(PlayerPrefs.GetInt("n_coin"));
        PlayerPrefs.SetInt("LevelReached",data.level);
        //Debug.Log("load"+PlayerPrefs.GetInt("LevelReached"));
        SceneManager.LoadScene("Room");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().setCoin(PlayerPrefs.GetInt("n_coin"));
        foreach (string weapon in data.weaponlist)
        {
            foreach (GameObject w in this.weaponslist)
            {
                if(w.name == weapon)
                {
                    GameObject ww = Instantiate(w,weaponHolder.transform);
                    ww.name = w.name;
                    //ww.transform.localScale = w.transform.localScale;

                    ww.transform.parent = weaponHolder.transform;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StarttoRoom : MonoBehaviour
{

    

    private void Start()
    {
        
    }
    void Update()
    {
        
       

    }

    public void NewGame()
    {
        SceneManager.LoadScene("Room");
        PlayerPrefs.DeleteAll();
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
    }

    public void Multiplayer()
    {
        print(123123);
        SceneManager.LoadScene("Multi_Room");
    }

    public void LoadGame()
    {
        //Debug.Log("load");
        PlayerData data = SaveSystem.LoadPlayer();
        PlayerPrefs.SetInt("n_coin",data.coin);
        //Debug.Log(PlayerPrefs.GetInt("n_coin"));
        PlayerPrefs.SetInt("LevelReached",data.level);
        SceneManager.LoadScene("Room");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().setCoin(PlayerPrefs.GetInt("n_coin"));
    }
}

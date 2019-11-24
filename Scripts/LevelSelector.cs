using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Image LevelSelectUI;
    private GameObject player;
    public Button[] LevelButton;

    private void Start()
    {
        
        int LevelReached = PlayerPrefs.GetInt("LevelReached");
        Debug.Log("level" + PlayerPrefs.GetInt("LevelReached"));
        for(int i = 0; i < LevelButton.Length; i++)
        {
            if(i+1>LevelReached)
            {
                LevelButton[i].interactable = false;
            }else{
               LevelButton[i].interactable = true; 
            }
            
        }
    }
    public void Select(string level)
    {
        print(level);
        LevelSelectUI.gameObject.SetActive(false);
        SceneManager.LoadScene(level);
        player = GameObject.FindGameObjectWithTag("Player");
        player.gameObject.transform.position = new Vector3(0, 0, 0);
        
    }

    public void CloseUI()
    {
        LevelSelectUI.gameObject.SetActive(false);
    }

}

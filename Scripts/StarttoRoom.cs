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

    }

    public void LoadGame()
    {

    }
}

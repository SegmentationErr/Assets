using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject PauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
 
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void LoadMenu()
    {
        print("loading");
        //Debug.Log("loading");
        SceneManager.LoadScene("Room");
        transform.parent.position = new Vector3(0, 0, 0);
        Time.timeScale = 1f;
        isPause = false;
        PauseMenuUI.SetActive(false);
    }

    public void Quit()
    {
        //Debug.Log("quit");
        Application.Quit();
    }

    public void SaveGame()
    {
        Debug.Log("save");
        SaveSystem.SavePlayer();

    }
}

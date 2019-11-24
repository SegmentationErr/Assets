using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class GameoverScripts : MonoBehaviour
{



    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
       /* GameObject[] goArray = SceneManager.GetSceneByBuildIndex(2).GetRootGameObjects();
        print(SceneManager.GetSceneByBuildIndex(2).name);
        //GetSceneByName("Room").GetRootGameObjects();
        if (goArray.Length > 0)
        {
            GameObject rootGo = goArray[0];
            print(rootGo);
            // Do something with rootGo here...
        }*/
        SceneManager.LoadScene("Room");
        transform.parent.position = new Vector3(0, 0, 0);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("move");
        transform.GetChild(2).gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverScripts : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }
}

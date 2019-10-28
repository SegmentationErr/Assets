using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FlashingTextScripts : MonoBehaviour
{
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            GetComponent<Text>().enabled = true;
        }

        if (timer >= 1)
        {
            GetComponent<Text>().enabled = false;
            timer = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Start Menu");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarttoRoom : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SceneManager.LoadScene("Room");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);

    }
}

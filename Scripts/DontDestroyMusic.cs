using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    // Start is called before the first frame update

        void Awake()
        {
            
            

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
       
            if ((scene.buildIndex == 2) || (scene.buildIndex == 3))
            {
            transform.gameObject.SetActive(true);
            DontDestroyOnLoad(transform.gameObject);

            }
            if (scene.buildIndex == 1)
            {
                transform.gameObject.SetActive(false);
                print("main scene");
            }
        }



}

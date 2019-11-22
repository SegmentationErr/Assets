using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMenu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject,2f);
            SceneManager.LoadScene("Start Menu");
            //Scene sceneToLoad = SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex - 2);
            //Scene sceneToLoad = SceneManager.GetSceneByName("level2");
            //Scene sceneToLoad = SceneManager.GetSceneByPath("Assets/Scenes/level2.unity"); 
            //Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex-1);

            //Scene sceneToLoad = SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex);
            //print((SceneManager.GetActiveScene().buildIndex) + " "+ sceneToLoad.name);
            //SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.MoveGameObjectToScene(collision.gameObject, sceneToLoad);
        }
    }
}

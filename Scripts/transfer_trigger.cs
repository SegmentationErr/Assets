using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transfer_trigger : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progressText;
    /*public static readonly string[] scenes = {
         "Path_To_Scene_1",
         "Path_To_Scene_2"
     };*/



    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(collision.gameObject);
            collision.transform.position = new Vector3(0,0,0);
            LoadLevel();
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

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}

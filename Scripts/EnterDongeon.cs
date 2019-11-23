using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterDongeon : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progressText;
    private GameObject[] players;
    private GameObject p;
    public Image LevelSelectorUI;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        //p = GameObject.Find("character");
        //print(p);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        //players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 2)
        {
            GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            print("Stasrt # player: " + players.Length);
            gameObjects[0].SetActive(false);
            //Destroy(gameObjects[0]);
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("move");



            //GameObject.FindGameObjectWithTag("Player")
            //GameObject.Find("character").SetActive(false);
            //transform
            //print("Stasrt # player: " + players.Length);
        }
    }

    private void Update()
    {
        /*players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length >= 2)
        {
            GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            //print("Stasrt # player: " + players.Length);
            gameObjects[0].SetActive(false);
            //players[0].SetActive(false);
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("move");


        }*/

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /*if (scene.buildIndex == 2)
        {
            if (players.Length >= 2)
            {
                GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
                //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                print("Stasrt # player: " + players.Length);
                gameObjects[0].SetActive(false);
                //players[0].SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("move");


            }
        }*/
        //welcome and start
        
    }


    public void LoadLevel()
    {

        
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //print("player collide");

            DontDestroyOnLoad(collision.gameObject);

            //collision.transform.position = new Vector3(0, 0, 0);
            //LoadLevel();
            LevelSelectorUI.gameObject.SetActive(true);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCurrLev : MonoBehaviour
{
    private GameObject player;
    private GameObject trans_gate;
    private bool end;
    private Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (Transform p in player.transform) {
            if (p.gameObject.name == "mapIcon") player = p.gameObject;
        }
        trans_gate = GameObject.FindGameObjectWithTag("Transfer_gate");
        end = false;
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !end) {
            Instantiate(trans_gate, new Vector3(player.transform.position.x + 2f, player.transform.position.y, player.transform.position.z), Quaternion.identity);
            if(currentScene.name == "level1")
            {
                PlayerPrefs.SetInt("LevelReached", 2);
            }else if (currentScene.name == "level2")
            {
                PlayerPrefs.SetInt("LevelReached", 3);
            }
            else if (currentScene.name == "level3")
            {
                PlayerPrefs.SetInt("LevelReached", 4);
            }
            end = true;
        }
    }
}

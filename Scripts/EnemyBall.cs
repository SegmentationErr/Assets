using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    public GameObject ball;
    public int ballNum = 15;
    private float timePast;


    // Update is called once per frame
    void Update()
    {
        timePast += Time.deltaTime;
        if (timePast >= 0.5) {
            timePast = 0;
            for (int i = 0; i < ballNum; i++) {
                Instantiate(ball, transform.position, Quaternion.Euler(0, 0, 360/ballNum*i));
            }
        }
    }
}

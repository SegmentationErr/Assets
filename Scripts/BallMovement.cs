using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 2;
    private float liftTime; 
    private float rotateSpeed = 1;


    // Update is called once per frame
    void Update()
    {
        liftTime += Time.deltaTime;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        transform.Rotate(0, 0, rotateSpeed);
        if (liftTime >= 3) {
            Destroy(gameObject);
        }
    }
}

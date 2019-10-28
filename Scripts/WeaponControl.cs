using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    // public float offset

    public GameObject bullet;
    public Transform shotPoint;

    private float deltaTime = 0;
    public float maxDeltaTime = 0.5f;
    public AudioSource shootSound;
    
    // Update is called once per frame
    void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);

        if (deltaTime >= maxDeltaTime) {
            if (Input.GetMouseButton(0)) {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                //Instantiate(bullet, shotPoint.position, Quaternion.identity);
                deltaTime = 0;
                shootSound.Play();
            }
        } else {
            deltaTime += Time.deltaTime;
        }
        
    }
}
